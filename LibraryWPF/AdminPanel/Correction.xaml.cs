using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for Correction.xaml
    /// </summary>
    public partial class Correction : Page
    {
        public ObservableCollection<StudentAnswer> csds;
        WPFLibDatabaseEntities dbc = new WPFLibDatabaseEntities();
        public void Render()
        {

            var rn = (from StudentAnswers in dbc.StudentAnswers
                      where
                        StudentAnswers.Mark_Obtained == null
                      select new
                      {
                          StudentAnswers.Roll_No
                      }).Distinct();
            listroll.Items.Clear();
            foreach (var rno in rn)
            {
                listroll.Items.Add(rno.Roll_No.ToString());
            }
            if (listroll.Items.Count < 1)
            {
               noanswers.Visibility = Visibility.Visible;
            }
            else
            {
              noanswers.Visibility = Visibility.Hidden;
            }
        }
        public Correction()
        {
            InitializeComponent();
            Render();

        }

        private void listroll_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listroll.Items.Count>0)
            {
                var qn = from StudentAnswers in dbc.StudentAnswers
                         where
                           StudentAnswers.Roll_No == listroll.SelectedValue.ToString() &&
                           StudentAnswers.Mark_Obtained == null
                         select new
                         {
                             StudentAnswers.Qno
                         };
                foreach (var qno in qn)
                {
                    listquest.Items.Add(qno.Qno.ToString());
                }
            }
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void listquest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listquest.Items.Count > 0)
            {
                int x = Convert.ToInt32(listquest.SelectedValue.ToString());
                var dis = from StudentAnswers in dbc.StudentAnswers
                          where
                            StudentAnswers.Qno ==x &&
                            StudentAnswers.Roll_No == listroll.SelectedValue.ToString()
                          select new
                          {
                              StudentAnswers.Question.Question1,
                              StudentAnswers.Answer,
                              StudentAnswers.Question.Picture,
                              Mark_Available = (decimal?)StudentAnswers.Question.Mark_Available
                          };
                foreach(var disq in dis)
                {
                    txtquest.Text = disq.Question1.ToString();
                    img.Source = LoadImage((byte[])disq.Picture);
                    txtanswer.Text = disq.Answer.ToString();
                    txtmrkalot.Text = disq.Mark_Available.ToString();
                }
            }
        }

        private void submitcorrectionbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int y = Convert.ToInt32(listquest.SelectedValue.ToString());
                int x = Convert.ToInt32(txtmrkscor.Text);
                var queryStudentAnswers =
                                            from StudentAnswers in dbc.StudentAnswers
                                            where
                                           StudentAnswers.Qno == y &&
                                           StudentAnswers.Roll_No == listroll.SelectedValue.ToString()
                                            select StudentAnswers;
                foreach (var StudentAnswers in queryStudentAnswers)
                {
                    StudentAnswers.Mark_Obtained = x;
                }

                //Inserting total marks from view to studentlogin table
                var mi = from sl in dbc.StudentModelLogins
                         join tm in dbc.View_TotalMarks on sl.Roll_No equals tm.Roll_No
                         select new { sl, tm };
                foreach (var item in mi)
                {
                    item.sl.Total_Mark = item.tm.TotalMark;
                }

                //saving changes to database
                dbc.SaveChanges();
                Clearfunc();
                Render();
            }
            catch(Exception)
            {
                MessageBox.Show("Check all fields.");
            }
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Clearfunc();
            Render();
        }
        public void Clearfunc()
        {
            listroll.Items.Clear();
            listquest.Items.Clear();
            txtquest.Clear();
            img.Source = null;
            txtmrkalot.Clear();
            txtmrkscor.Clear();
            txtanswer.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;


namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public int status=0;
        WPFLibDatabaseEntities entities = new WPFLibDatabaseEntities();
        public AdminPanel()
        {
            InitializeComponent();
            adminframe.Content = new PostQuestion();
            status = 1;
        }

        private void postq_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new PostQuestion();
            status = 1;
        }

        private void correc_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Correction();
            status = 2;
        }

        private void ranki_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Ranking();
            status = 3;
        }

        private void answr_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Student_Answers();
            status = 4;
        }

        private void stulist_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Student_List();
            status = 5;
        }

        private void quelist_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Question_List();
            status = 6;
        }

        private void Misc_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Misc();
            status = 7;
        }

        private void discipline_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Discipline();
            status = 8;
        }

        private void adminframe_ContentRendered(object sender, EventArgs e)
        {
            var mi = from sl in entities.StudentModelLogins
                     join tm in entities.View_TotalMarks on sl.Roll_No equals tm.Roll_No
                     select new { sl, tm };
            foreach (var item in mi)
            {
                item.sl.Total_Mark = item.tm.TotalMark;
            }
            var di = from sl in entities.StudentModelLogins
                     join de in entities.View_DisciplinedMarks on sl.Roll_No equals de.Roll_No
                     select new { sl, de };
            foreach (var item in di)
            {
                item.sl.Total_Mark = item.sl.Total_Mark - (item.de.Deduction);
            }
            entities.SaveChanges();
            switch (status)
            {
                

                case 1:
                    postq.Background = new SolidColorBrush(Color.FromArgb(221,221,221,100));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 2:
                    correc.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 3:
                    ranki.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 4:
                    answr.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 5:
                    stulist.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 6:
                    quelist.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 7:
                    misc.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    discipline.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;

                case 8:
                    discipline.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    postq.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    correc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    ranki.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    answr.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    stulist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    quelist.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    misc.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using LibraryWPF;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for Questions.xaml
    /// </summary>
    
    public partial class Questions : Page
    {
        WPFLibDatabaseEntities dbq = new WPFLibDatabaseEntities();
        public ObservableCollection<Question> Qsds;
        public void Render() //made a public function for creating a collection of table "Question" for better UI performance
        {
            Qsds = new ObservableCollection<Question>();
            var qn = from q in dbq.Questions
                     select q;
            foreach (var qnos in qn)
            {
                Question q = new Question();
                q.Qno = qnos.Qno;
                q.Question1 = qnos.Question1;
                q.Picture = qnos.Picture;
                q.PostDate = qnos.PostDate;
                Qsds.Add(q);
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

        public string Roll;
        public Questions(string roll)
        {
            InitializeComponent();
            Roll = roll;
            //calling created function Render
            Render();
            //.Select(d => d.Qno);
            StudentAnswer studentAnswer = new StudentAnswer();
            Question question = new Question();
            //var sc = Qsds.Where(!(c => c.PostDate>=DateTime.Now));
            var sc = from s in dbq.Questions
                     where !dbq.StudentAnswers.Any(es=>(es.Qno==s.Qno)) && (s.PostDate>DateTime.Now)
                     select s;
            foreach(var i in sc)
            {

                qnolist.ItemsSource = sc.Select(s=>s.Qno);
            }
            
        }
        
        private void qnolist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var qc = Qsds.FirstOrDefault(a => a.Qno.Equals(Convert.ToInt32(qnolist.SelectedValue.ToString())));
            if (qc != null)
            {
                qntxt.Text = qc.Question1;
                img.Source = LoadImage((byte[])qc.Picture);
            }
            
        }

        private void submitbtn_Click(object sender, RoutedEventArgs e)
        {
            StudentAnswer sa = new StudentAnswer();
            sa.Roll_No = Roll;
            sa.Qno = Convert.ToInt32(qnolist.SelectedValue.ToString());
            sa.Answer = answertxt.Text;
            dbq.StudentAnswers.Add(sa);
            dbq.SaveChanges();
            answertxt.Clear();
            qntxt.Clear();
            img.Source = null;
        }
    }
}

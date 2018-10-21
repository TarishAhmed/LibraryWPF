using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Drawing.Imaging;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for PostQuestion.xaml
    /// </summary>
    public partial class PostQuestion : Page
    {
        public string filename; //"filename" string created for the purpose of storing the source of the image
        public PostQuestion()
        {
            InitializeComponent();
        }

        private void picturebtn_Click(object sender, RoutedEventArgs e)
        {
            //File Dialog for browsing image file
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //displaying image from source to image box
                MyImage.Source = new BitmapImage(new Uri(op.FileName));
                //getting the file name from the dialogbox to public string filename
                filename = op.FileName;
            }
        }
        public static class DtHelper
        {
            public static DateTime myTime
            {
                get { return DateTime.Today.AddDays(-6); }
            }
        }
        private void postbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                        //Using ADO.Net Entities for insertion operation
                        WPFLibDatabaseEntities entities = new WPFLibDatabaseEntities();
                        Question question = new Question();
                        question.Question1 = qstntxt.Text;
                        question.PostDate = expdt.SelectedDate.Value;
                        question.Mark_Available = Convert.ToInt32(mrkalottxt.Text);
                        if (MyImage.Source != null)
                        {
                            //Begin Convert Image from Source to Byte
                            FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                            StreamReader reader = new StreamReader(stream);
                            Byte[] ImgData = new Byte[stream.Length - 1];
                            stream.Read(ImgData, 0, (int)stream.Length - 1);
                            //End
                            question.Picture = ImgData;
                        }
                        entities.Questions.Add(question);
                        entities.SaveChanges();
                        //cleaning up components after insertion
                        qstntxt.Clear();
                        mrkalottxt.Clear();
                        MyImage.Source = null;
                        expdt.SelectedDate = null;
            }
            catch(Exception)
            {
                MessageBox.Show("Please Check All Fields","Error");
            }
            
        }
    }
}


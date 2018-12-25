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
    /// Interaction logic for StudentPanel.xaml
    /// </summary>
    public partial class StudentPanel : Window
    {
        private string Roll;
        public int status = 1;
        public StudentPanel(string roll, string nam)
        {
            InitializeComponent();
            Roll = roll;
            rolltext.Text = roll;
            nametext.Text = nam;
            studframe.Content = new Questions(roll);
        }
        private void qstns_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Questions(Roll);
            status = 1;
        }

        private void mrks_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Marks(Roll);
            status = 2;
        }

        private void rnk_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Ranking();
            status = 3;
        }

        private void book_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Displinary_Actions(Roll);
            status = 4;
        }
        private void studframe_ContentRendered(object sender, EventArgs e)
        {
            switch (status)
            {


                case 1:
                    qstns.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    mrks.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    rnk.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    book.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;
                case 2:
                    mrks.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    qstns.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    rnk.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    book.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;
                case 3:
                    rnk.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    mrks.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    qstns.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    book.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;
                case 4:
                    book.Background = new SolidColorBrush(Color.FromArgb(221, 221, 221, 100));
                    mrks.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    qstns.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    rnk.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CDDDDDD"));
                    break;
            }
        }

        
    }
}

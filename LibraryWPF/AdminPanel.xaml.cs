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
        public AdminPanel()
        {
            InitializeComponent();
            adminframe.Content = new PostQuestion();
        }

        private void postq_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new PostQuestion();

        }

        private void correc_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Correction();
        }

        private void ranki_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Ranking();
        }

        private void answr_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Student_Answers();
        }

        private void stulist_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Student_List();
        }

        private void quelist_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Question_List();
        }

        private void Misc_Click(object sender, RoutedEventArgs e)
        {
            adminframe.Content = new Misc();
        }
    }
}

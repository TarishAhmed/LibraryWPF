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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Admin.Visibility = Visibility.Visible;
            Student.Visibility = Visibility.Collapsed;
            frame1.Content = new StudentLogin();

        }




        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content=new AdminLogin();
            Admin.Visibility = Visibility.Collapsed;
            Student.Visibility = Visibility.Visible;
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new StudentLogin();
            Student.Visibility = Visibility.Collapsed;
            Admin.Visibility = Visibility.Visible;
        }
    }
}

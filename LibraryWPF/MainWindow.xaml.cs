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
        bool loginsignupswitch = false;
        bool adminstudentswitch = false;
        public MainWindow()
        {
            InitializeComponent();
            Admin.Visibility = Visibility.Visible;
            frame1.Content = new StudentLogin();

        }




        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            
            switch (adminstudentswitch)
            {
                case false:
                    frame1.Content = new AdminLogin();
                    adminstudentswitch = true;
                    Admin.Content = "Student";
                    break;
                case true:
                    frame1.Content = new StudentLogin();
                    adminstudentswitch = false;
                    Admin.Content = "Admin";
                    break;
            }
        }

        private void Student_Click(object sender, RoutedEventArgs e)
        {
        }

        private void signupwindowbtn_Click(object sender, RoutedEventArgs e)
        {

            switch (loginsignupswitch)
            {
                case false:
                    frame1.Content = new StudentSignup();
                    loginsignupswitch = true;
                    signupwindowbtn.Content = "Login";
                    break;
                case true:
                    frame1.Content = new StudentLogin();
                    loginsignupswitch = false;
                    signupwindowbtn.Content = "Signup";
                    break;
            }
            

        }
    }
}

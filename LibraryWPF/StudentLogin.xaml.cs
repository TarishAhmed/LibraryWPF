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
    /// Interaction logic for StudentLogin.xaml
    /// </summary>
    
    public partial class StudentLogin : Page
    {
        public string roll;
        public string nam;
        public StudentLogin()
        {
            InitializeComponent();
            logidtxt.Focus();

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if(logidtxt.Text!="" && logpasstxt.Password!="")
            { 
                try
                {
                    WPFLIBDATABASEEntities dbs = new WPFLIBDATABASEEntities();
                    if (logidtxt.Text != string.Empty || logpasstxt.Password != string.Empty)
                    {
                        var studs = dbs.StudentModelLogins.FirstOrDefault(a => a.Roll_No.Equals(logidtxt.Text));
                        if (studs != null)
                        {
                            if(studs.Password.Equals(logpasstxt.Password))
                            { 
                                roll = studs.Roll_No;
                                nam = studs.Name;
                                StudentPanel stpa = new StudentPanel(roll, nam);
                                Application.Current.Windows[0].Close();
                                stpa.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Password Incorrect!");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Account not found.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Fill both fields.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(""+ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Don't leave a blank field.");
            }
        }

        private void GSignupbtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void GSigninbtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

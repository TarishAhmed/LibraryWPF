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
using System.Data.Entity;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for StudentSignup.xaml
    /// </summary>
    public partial class StudentSignup : Page
    {
        public StudentSignup()
        {
            InitializeComponent();
        }

        private void Signup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WPFLIBDATABASEEntities dbe = new WPFLIBDATABASEEntities();
                if (signidtxt.Text != string.Empty || signpasstxt.Password != string.Empty||signconpasstxt.Password!=string.Empty)
                {
                    var studentsid = dbe.StudentModelLogins.FirstOrDefault(a => a.Roll_No.Equals(signidtxt.Text));
                    if(studentsid!=null)
                    {
                        if(studentsid.Password==null)
                        {
                            if(signpasstxt.Password != "")
                            {
                                if (signpasstxt.Password == signconpasstxt.Password)
                                {
                                    using (dbe)
                                    {
                                        var query = (from StudentModelLogin in dbe.StudentModelLogins
                                                     where StudentModelLogin.Roll_No == signidtxt.Text
                                                     select StudentModelLogin).First();
                                        query.Password = signpasstxt.Password;
                                        dbe.Entry(query).State = EntityState.Modified;
                                        dbe.SaveChanges();
                                        signidtxt.Clear();
                                        signpasstxt.Clear();
                                        signconpasstxt.Clear();
                                        MessageBox.Show("Account Created.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Password fields does not match.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Don't leave a field blank.");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("You already have a account.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid ID");
                    }
                }
                else
                {
                    MessageBox.Show("Don't leave a field blank.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
            stud.Focus();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            WPFLibDatabaseEntities dbs = new WPFLibDatabaseEntities();
            if (stud.Text != string.Empty)
            {
                var studs = dbs.StudentModelLogins.FirstOrDefault(a=>a.Roll_No.Equals(stud.Text));
                if (studs != null)
                {
                    roll=studs.Roll_No;
                    nam = studs.Name;
                    StudentPanel stpa = new StudentPanel(roll,nam);
                    Application.Current.Windows[0].Close();
                    stpa.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Roll No.");
                }
            }
        }
    }
}

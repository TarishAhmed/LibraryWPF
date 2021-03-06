﻿using System;
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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Page
    {
        public AdminLogin()
        {
            InitializeComponent();
            Admin.Focus();
        }

        private void Loginbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WPFLIBDATABASEEntities dbe = new WPFLIBDATABASEEntities();
                if (Admin.Text != string.Empty || AdminPassword.Password != string.Empty)
                {
                    var Admins = dbe.AdminLogins.FirstOrDefault(a => a.AdminID.Equals(Admin.Text));
                    if (Admins != null)
                    {
                        if (Admins.Password.Equals(AdminPassword.Password))
                        {
                            AdminPanel adpa = new AdminPanel();
                            Application.Current.Windows[0].Close();
                            adpa.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Password Incorrect");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Admin Invalid");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);
            }
        }

    }
}


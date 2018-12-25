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
using System.Windows.Threading;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for Discipline.xaml
    /// </summary>
    public partial class Discipline : Page
    {
        WPFLIBDATABASEEntities context = new WPFLIBDATABASEEntities();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public bool check = false;
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            nameroll.Text = "Name";
            check = true;
            Render();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            nameroll.Text = "Roll No.";
            check = false;
            Render();
        }
        public void Render()
        {
            var studlogi = from c in context.StudentModelLogins
                           select new { c.Name, ID = c.Roll_No };
            studcombo.Focus();
            studcombo.ItemsSource = studlogi.ToList();
            switch (check)
            {
                case true:
                    studcombo.DisplayMemberPath = "Name";
                    break;
                case false:
                    studcombo.DisplayMemberPath = "ID";
                    break;
            }
            studcombo.SelectedValuePath = "ID";
        }
        public Discipline()
        {
            InitializeComponent();
            Render();
            dispatcherTimer.Tick += DispatcherTimer_Tick;

        }

        private void discsubmit_Click(object sender, RoutedEventArgs e)
        {
            
            using (context)
            {
                DisciplineModel objdiscipline = new DisciplineModel();
                objdiscipline.Roll_No = studcombo.SelectedValue.ToString();
                objdiscipline.Deduction = Convert.ToInt32(disciplinetxt.Text);
                objdiscipline.Remarks = remarktxt.Text;
                objdiscipline.Date = DateTime.Now;
                context.DisciplineModels.Add(objdiscipline);
                context.SaveChanges();
                disciplinetxt.Clear();
                remarktxt.Clear();
            }
            status.Text = "Changes Updated!";
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            status.Visibility = Visibility.Collapsed;
        }

        
    }
}

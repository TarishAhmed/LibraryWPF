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
        WPFLibDatabaseEntities context = new WPFLibDatabaseEntities();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        
        public Discipline()
        {
            
            var studlogi = from c in context.StudentModelLogins
                       select new { c.Name,ID = c.Roll_No };
            InitializeComponent();
            studcombo.Focus();
            studcombo.ItemsSource = studlogi.ToList();
            studcombo.DisplayMemberPath = "Name";
            studcombo.SelectedValuePath = "ID";
            dispatcherTimer.Tick += DispatcherTimer_Tick;

        }

        private void discsubmit_Click(object sender, RoutedEventArgs e)
        {
            using (context)
            {
                Discipline objdiscipline = new Discipline();
                objdiscipline.Roll_No = studcombo.SelectedValue.ToString();
                objdiscipline.Deduction = Convert.ToInt32(disciplinetxt.Text);
                context.Disciplines.Add(objdiscipline);
                context.SaveChanges();
                disciplinetxt.Clear();              
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

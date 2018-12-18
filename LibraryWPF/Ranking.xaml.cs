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
    /// Interaction logic for Ranking.xaml
    /// </summary>
    public partial class Ranking : Page
    {
        WPFLibDatabaseEntities entities = new WPFLibDatabaseEntities();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Ranking()
        {
            InitializeComponent();
            Generate.Focus();
            dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            status.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = (from c in entities.StudentModelLogins
                        where c.Total_Mark>0
                       orderby c.Total_Mark descending
                       select new { c.Roll_No, c.Name ,c.Gender, c.Total_Mark }).Take(10);

            ContentDataGrid.ItemsSource = data.ToList();
            status.Text = "Please update changes from misc before viewing!";
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                var data = (from c in entities.StudentModelLogins
                            where c.Total_Mark > 0
                            orderby c.Total_Mark descending
                            select new { c.Roll_No, c.Name, c.Gender, c.Total_Mark }).Take(10);

                ContentDataGrid.ItemsSource = data.ToList();
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

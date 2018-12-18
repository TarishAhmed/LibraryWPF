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
    /// Interaction logic for Misc.xaml
    /// </summary>
    public partial class Misc : Page
    {
        WPFLibDatabaseEntities dbm = new WPFLibDatabaseEntities();
        public Misc()
        {
            InitializeComponent();
        }

        private void updatetot_Click(object sender, RoutedEventArgs e)
        {
            var mi = from sl in dbm.StudentModelLogins
                     join tm in dbm.View_TotalMarks on sl.Roll_No equals tm.Roll_No
                     select new { sl, tm };
            foreach(var item in mi)
            {
                item.sl.Total_Mark = item.tm.TotalMark;
            }
            var di = from sl in dbm.StudentModelLogins
                     join de in dbm.View_DisciplinedMarks on sl.Roll_No equals de.Roll_No
                     select new { sl, de };
            foreach (var item in di)
            {
                item.sl.Total_Mark = item.sl.Total_Mark - (item.de.Deduction);
            }
            dbm.SaveChanges();
        }
    }
}

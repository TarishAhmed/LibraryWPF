using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for Marks.xaml
    /// </summary>
    public partial class Marks : Page
    {
        WPFLibDatabaseEntities wPFLib = new WPFLibDatabaseEntities();
        public ObservableCollection<StudentLogin> slds;
        string Roll;
        public Marks(string roll)
        {
            InitializeComponent();
            Roll = roll;   
        }
        public void render()
        {
            var slds = wPFLib.StudentModelLogins.FirstOrDefault(a => a.Roll_No.Equals(Roll));
            marklbl.Text = ""+slds.Total_Mark;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            render();
        }
    }
}

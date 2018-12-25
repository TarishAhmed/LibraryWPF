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
    /// Interaction logic for Displinary_Actions.xaml
    /// </summary>
    public partial class Displinary_Actions : Page
    {
        WPFLIBDATABASEEntities context = new WPFLIBDATABASEEntities();
        public string Roll;
        public Displinary_Actions(string roll)
        {
            InitializeComponent();
            Roll = roll;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            var displogi = (from c in context.DisciplineModels
                            orderby c.Index ascending
                            where c.Roll_No == Roll
                            select new { sl=(from o in context.DisciplineModels where o.Index<c.Index select o).Count()+1,c.Index, c.Date, c.Deduction, c.Remarks }).ToList();
            bootxt.ItemsSource = displogi.ToList();
            bootxt.DisplayMemberPath = "sl";
            bootxt.SelectedValuePath = "Index";


        }

        private void bootxt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i;
            i = Convert.ToInt32(bootxt.SelectedValue.ToString());
            var books = context.DisciplineModels.First(x => x.Index == i );
            datxt.Text = books.Date.ToString();
            deductxt.Text = books.Deduction.ToString();
            retxt.Text = books.Remarks.ToString();
        }
    }
}

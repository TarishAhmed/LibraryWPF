using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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
    /// Interaction logic for Student_List.xaml
    /// </summary>
    
    public partial class Student_List : Page
    {
        
        public Student_List()
        {
            InitializeComponent();
            loadgrid();
            //initializing datagrid

            //context = new WPFLibDatabaseEntities();
            ////set roll to datagrid
            //DataGridTextColumn rollcol = new DataGridTextColumn();
            //Binding rollb = new Binding("Roll_No");
            //rollcol.Binding = rollb;
            //rollcol.Header = "Roll Number";
            //studgrid.Columns.Add(rollcol);
            ////set name to datagrid
            //DataGridTextColumn namecol = new DataGridTextColumn();
            //Binding Nameb = new Binding("Name");
            //namecol.Binding = Nameb;
            //namecol.Header = "Name";
            //studgrid.Columns.Add(namecol);
            ////set Gender to datagrid
            //DataGridTextColumn Gendercol = new DataGridTextColumn();
            //Binding Genderb = new Binding("Gender");
            //Gendercol.Binding = Genderb;
            //Gendercol.Header = "Gender";
            //studgrid.Columns.Add(Gendercol);
            ////set Total_Mark to datagrid
            //DataGridTextColumn Total_Markcol = new DataGridTextColumn();
            //Binding Total_Markb = new Binding("Total_Mark");
            //Total_Markcol.Binding = Total_Markb;
            //Total_Markcol.Header = "Total Mark";
            //studgrid.Columns.Add(Total_Markcol);


        }

        private void loadgrid()
        {
            WPFLIBDATABASEEntities context = new WPFLIBDATABASEEntities();
            var data = from c in context.StudentModelLogins
                       select new { c.Roll_No, c.Name, c.Gender, c.Total_Mark };
            studgrid.ItemsSource = data.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {


            //context = new WPFLibDatabaseEntities();
            //context.StudentModelLogins.Load();
            


            //////context.StudentModelLogins.Load();

            //context.StudentModelLogins.Load();/*.Select(c => new { c.Roll_No, c.Name, c.Gender, c.Total_Mark })*/
            ////context.StudentModelLogins.Select(c => new { c.Roll_No, c.Name, c.Gender, c.Total_Mark });
            //studgrid.DataContext = context.StudentModelLogins.Local;


        }
    }
}

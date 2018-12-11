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
    /// Interaction logic for Question_List.xaml
    /// </summary>
    public partial class Question_List : Page
    {
        public Question_List()
        {
            InitializeComponent();
            loadgrid();
        }
        private void loadgrid()
        {
            WPFLibDatabaseEntities context = new WPFLibDatabaseEntities();
            var data = from c in context.Questions
                       select new { c.Qno, c.Question1, c.Mark_Available, c.Picture , c.PostDate };
            questionDataGrid.ItemsSource = data.ToList();
        }
    }
}

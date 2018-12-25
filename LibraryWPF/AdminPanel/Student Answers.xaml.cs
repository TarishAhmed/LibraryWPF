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
    /// Interaction logic for Student_Answers.xaml
    /// </summary>
    public partial class Student_Answers : Page
    {
        public Student_Answers()
        {
            InitializeComponent();
            loadgrid();
        }
        private void loadgrid()
        {
            WPFLIBDATABASEEntities context = new WPFLIBDATABASEEntities();
            var data = from c in context.StudentAnswers
                       select c; /*new { c.SAno, c.Roll_No, c.Answer, c.Qno , c.Mark_Obtained };*/
            studentAnswerDataGrid.ItemsSource = data.ToList();
        }
    }
}

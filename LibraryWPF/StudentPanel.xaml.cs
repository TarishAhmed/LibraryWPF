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
using System.Windows.Shapes;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for StudentPanel.xaml
    /// </summary>
    public partial class StudentPanel : Window
    {
        private string Roll;
        public StudentPanel(string roll, string nam)
        {
            InitializeComponent();
            Roll = roll;
            rolltext.Text = roll;
            nametext.Text = nam;
            studframe.Content = new Questions(roll);
        }
        private void qstns_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Questions(Roll);
        }

        private void mrks_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Marks(Roll);
        }

        private void rnk_Click(object sender, RoutedEventArgs e)
        {
            studframe.Content = new Ranking();
        }
    }
}

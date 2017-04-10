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

namespace Spa_salon.Views
{
    /// <summary>
    /// Логика взаимодействия для SalonsUserControl.xaml
    /// </summary>
    public partial class SalonsUserControl : UserControl
    {
        public SalonsUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var printWindow = new PrintWindow();
            printWindow.Title = "Дохід spa-салону";
            printWindow.Show();
        }
    }
}

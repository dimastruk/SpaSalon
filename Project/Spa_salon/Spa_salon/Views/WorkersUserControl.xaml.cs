﻿using System;
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
    /// Логика взаимодействия для WorkersUserControl.xaml
    /// </summary>
    public partial class WorkersUserControl : UserControl
    {
        public WorkersUserControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var printWindow = new PrintWindow();
            printWindow.Title = "Дохід працівника";
            printWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new RegistrationWindow();
            window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new SpecialityWindow();
            window.DataContext = Application.Current.MainWindow.DataContext;
            window.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var window = new WorkerScheduleWindow();
            window.DataContext = Application.Current.MainWindow.DataContext;
            window.Show();
        }
    }
}

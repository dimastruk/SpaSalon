using IssueTracker.Commands;
using Spa_salon.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Spa_salon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new AuthorizeViewModel();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
    }
}
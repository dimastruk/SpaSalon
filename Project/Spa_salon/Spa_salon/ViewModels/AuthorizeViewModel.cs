using IssueTracker.Commands;
using Spa_salon.Common.Models;
using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Spa_salon.ViewModels
{
    public class AuthorizeViewModel : ViewModelBase
    {
        #region Properties
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion

        #region Commands
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new DelegateCommand(LoginCommand_Execute, LoginCommand_CanExecute);
                }

                return _loginCommand;
            }
        }

        private bool LoginCommand_CanExecute(object o)
        {
            var passwordBox = o as PasswordBox;
            Password = passwordBox.Password;
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Password);
        }

        private void LoginCommand_Execute(object o)
        {
            try
            {
                var workersService = new WorkersService();
                var loginWorker = workersService.Login(Name, Password);
                if(loginWorker != null)
                {
                    Authorize(loginWorker);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        #endregion

        #region Private Methods
        internal void Authorize(IWorker worker)
        {
            var workWindow = new WorkWindow();
            workWindow.DataContext = this;
            SetMainWindow(workWindow);
        }
        internal void SetMainWindow(Window window)
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = window;
            Application.Current.MainWindow.Show();
        }
        #endregion
    }
}

using IssueTracker.Commands;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using Spa_salon.Common.Services;
using Spa_salon.Common.Models;

namespace Spa_salon.Views
{
    public interface ISettingsViewModel : INotifyPropertyChanged
    {
        ICommand ChangePasswordCommand { get; }
    }
    /// <summary>
    /// Логика взаимодействия для SettingsUserControl.xaml
    /// </summary>
    public partial class SettingsUserControl : UserControl, ISettingsViewModel
    {
        public SettingsUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        private ICommand _changePasswordCommand;

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (_changePasswordCommand == null)
                {
                    _changePasswordCommand = new DelegateCommand(ChangePasswordCommand_Execute, ChangePasswordCommand_CanExecute);
                }

                return _changePasswordCommand;
            }
        }

        private bool ChangePasswordCommand_CanExecute(object o)
        {
            return !string.IsNullOrEmpty(OldPassword.Password) && !string.IsNullOrEmpty(NewPassword.Password) && !string.IsNullOrEmpty(ConfirmedNewPassword.Password);
        }

        private void ChangePasswordCommand_Execute(object o)
        {
            try
            {
                if(NewPassword.Password != ConfirmedNewPassword.Password)
                {
                    throw new Exception("Підтверджений пароль не співпадає!");
                }

                var workersService = new WorkersService();
                workersService.ChangePassword(App.CurrentUser, OldPassword.Password, NewPassword.Password);

                OldPassword.Password = string.Empty;
                NewPassword.Password = string.Empty;
                ConfirmedNewPassword.Password = string.Empty;

                MessageBox.Show("Пароль успішно змінено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
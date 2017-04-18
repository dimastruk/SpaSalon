using IssueTracker.Commands;
using Spa_salon.Common.Models;
using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Spa_salon.ViewModels
{
    public interface IClientsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IClientViewModel> Clients { get; }
        IClientViewModel SelectedClient { get; set; }
        ICommand ChangeClientInfoCommand { get; }
        string NewLastName { get; set; }
        string NewFirstName { get; set; }
        string NewPhoneNumber { get; set; }
    }

    public class ClientsViewModel : ViewModelBase, IClientsViewModel
    {
        #region Constructors
        public ClientsViewModel()
        {
            var clientService = new ClientService();
            Clients = new ObservableCollection<IClientViewModel>();

            foreach(var client in clientService.GetClients())
            {
                Clients.Add(new ClientViewModel() { ClientId = client.ClientId, LastName = client.LastName, FirstName = client.FirstName, PhoneNumber = client.PhoneNumber });
            }
        }
        #endregion

        #region Properties
        public ObservableCollection<IClientViewModel> Clients
        {
            get;
        }

        private IClientViewModel _selectedClient;
        public IClientViewModel SelectedClient
        {
            get
            {
                return _selectedClient;
            }

            set
            {
                _selectedClient = value;
                NewLastName = _selectedClient.LastName;
                NewFirstName = _selectedClient.FirstName;
                NewPhoneNumber = _selectedClient.PhoneNumber.ToString();
                OnPropertyChanged("SelectedClient");
            }
        }

        private string _newLastName;
        public string NewLastName
        {
            get
            {
                return _newLastName;
            }

            set
            {
                _newLastName = value;
                OnPropertyChanged("NewLastName");
            }
        }

        private string _newFirstName;
        public string NewFirstName
        {
            get
            {
                return _newFirstName;
            }

            set
            {
                _newFirstName = value;
                OnPropertyChanged("NewFirstName");
            }
        }

        private string _newPhoneNumber;
        public string NewPhoneNumber
        {
            get
            {
                return _newPhoneNumber;
            }

            set
            {
                _newPhoneNumber = value;
                OnPropertyChanged("NewPhoneNumber");
            }
        }
        #endregion

        #region Commands
        private ICommand _changeClientInfoCommand;
        public ICommand ChangeClientInfoCommand
        {
            get
            {
                if (_changeClientInfoCommand == null)
                {
                    _changeClientInfoCommand = new DelegateCommand(ChangeClientInfoCommand_Execute, ChangeClientInfoCommand_CanExecute);
                }

                return _changeClientInfoCommand;
            }
        }

        private bool ChangeClientInfoCommand_CanExecute(object o)
        {
            if((SelectedClient == null))
            {
                return false;
            }
            else
                return !string.IsNullOrEmpty(NewLastName) && !string.IsNullOrEmpty(NewFirstName) && !string.IsNullOrEmpty(NewPhoneNumber);
        }

        private void ChangeClientInfoCommand_Execute(object o)
        {
            try
            {
                var clientService = new ClientService();

                var clientModel = new Client(SelectedClient.ClientId, SelectedClient.LastName, SelectedClient.FirstName, SelectedClient.PhoneNumber);

                clientService.ChangeClientInfo(clientModel, NewLastName, NewFirstName, NewPhoneNumber);
                var client = Clients.FirstOrDefault(cl => cl.ClientId == SelectedClient.ClientId);
                client.LastName = clientModel.LastName;
                client.FirstName = clientModel.FirstName;
                client.PhoneNumber = clientModel.PhoneNumber;
                MessageBox.Show("Дані успішно змінено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
        #endregion
    }
}
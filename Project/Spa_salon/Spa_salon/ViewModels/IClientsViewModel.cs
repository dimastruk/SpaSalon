using IssueTracker.Commands;
using Spa_salon.Common.Enumerations;
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
        ObservableCollection<IClientViewModel> Clients { get; set; }
        ObservableCollection<IClientViewModel> AllClients { get; }
        IClientViewModel SelectedClient { get; set; }
        ICommand ChangeClientInfoCommand { get; }
        ICommand SearchClientCommand { get; }
        ICommand AddClientCommand { get; }
        ClientFilters ClientFilter { get; set; }
        string SearchString { get; set; }
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
            AllClients = new ObservableCollection<IClientViewModel>();

            foreach(var client in clientService.GetClients())
            {
                AllClients.Add(new ClientViewModel() { ClientId = client.ClientId, LastName = client.LastName, FirstName = client.FirstName, PhoneNumber = client.PhoneNumber });
            }

            Clients = AllClients;

            ClientFilter = ClientFilters.LastName;
        }
        #endregion

        #region Properties
        private ObservableCollection<IClientViewModel> _clients;
        public ObservableCollection<IClientViewModel> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
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
                if (_selectedClient != null)
                {
                    NewLastName = _selectedClient.LastName;
                    NewFirstName = _selectedClient.FirstName;
                    NewPhoneNumber = _selectedClient.PhoneNumber.ToString();
                }
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

        private string _searchString;
        public string SearchString
        {
            get
            {
                return _searchString;
            }

            set
            {
                _searchString = value;
                if(string.IsNullOrEmpty(_searchString))
                {
                    Clients = AllClients;
                }
                OnPropertyChanged("SearchString");
            }
        }

        private ClientFilters _clientFilter;
        public ClientFilters ClientFilter
        {
            get
            {
                return _clientFilter;
            }

            set
            {
                _clientFilter = value;
                OnPropertyChanged("ClientFilter");
            }
        }

        public ObservableCollection<IClientViewModel> AllClients
        {
            get;
            set;
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

        private ICommand _searchClientCommand;
        public ICommand SearchClientCommand
        {
            get
            {
                if(_searchClientCommand == null)
                {
                    _searchClientCommand = new DelegateCommand(SearchClientCommand_Execute, SearchClientCommand_CanExecute);
                }

                return _searchClientCommand;
            }
        }

        private ICommand _addClientCommand;
        public ICommand AddClientCommand
        {
            get
            {
                if(_addClientCommand == null)
                {
                    _addClientCommand = new DelegateCommand(AddClientCommand_Execute, AddClientCommand_CanExecute);
                }

                return _addClientCommand;
            }
        }

        private bool AddClientCommand_CanExecute(object o)
        {
            return !string.IsNullOrEmpty(NewLastName) && !string.IsNullOrEmpty(NewFirstName) && !string.IsNullOrEmpty(NewPhoneNumber);
        }

        private void AddClientCommand_Execute(object o)
        {
            try
            {
                var clientService = new ClientService();
                clientService.AddClient(NewLastName, NewFirstName, NewPhoneNumber);

                AllClients.Clear();
                foreach (var client in clientService.GetClients())
                {
                    AllClients.Add(new ClientViewModel() { ClientId = client.ClientId, LastName = client.LastName, FirstName = client.FirstName, PhoneNumber = client.PhoneNumber });
                }

                MessageBox.Show("Клієнта успішно додано!");
                Clients = AllClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private bool SearchClientCommand_CanExecute(object o)
        {
            return !string.IsNullOrEmpty(SearchString);
        }

        private void SearchClientCommand_Execute(object o)
        {
            try
            {
                switch(ClientFilter)
                {
                    case ClientFilters.LastName:
                    {
                        Clients = new ObservableCollection<IClientViewModel>(AllClients.Where(cl => cl.LastName == SearchString).ToList());
                        break;
                    }

                    case ClientFilters.FirstName:
                    {
                        Clients = new ObservableCollection<IClientViewModel>(AllClients.Where(cl => cl.FirstName == SearchString).ToList());
                        break;
                    }

                    case ClientFilters.PhoneNumber:
                    {
                        Clients = new ObservableCollection<IClientViewModel>(AllClients.Where(cl => cl.PhoneNumber.ToString() == SearchString).ToList());
                        break;
                    }

                    default:
                    {
                        Clients = AllClients;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
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
                Clients = AllClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
        #endregion
    }
}
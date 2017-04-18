using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IClientViewModel : INotifyPropertyChanged
    {
        int ClientId { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        long PhoneNumber { get; set; }
    }

    public class ClientViewModel : ViewModelBase, IClientViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private long _phoneNumber;
        public long PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        private int _clientId;
        public int ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                _clientId = value;
                OnPropertyChanged("ClientId");
            }
        }
    }
}
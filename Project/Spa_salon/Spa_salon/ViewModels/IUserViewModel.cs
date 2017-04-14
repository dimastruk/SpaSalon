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

namespace Spa_salon.ViewModels
{

    public interface IUserViewModel : INotifyPropertyChanged
    {
        #region Properties
        int WorkerId { get; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        DateTime DateOfBirth { get; set; }
        string PassportNumber { get; set; }
        int WorkbookNumber { get; set; }
        int MedicalbookNumber { get; set; }
        long IdNumber { get; set; }
        long PhoneNumber { get; set; }
        string Address { get; set; }
        IPosition Position { get; }
        ISalon Salon { get; }
        string LoginName { get; }
        WorkerStatus Status { get; }
        IOrderViewModel Order { get; }
        IWorkerViewModel Worker { get; }
        IScheduleViewModel Schedule { get; }
        #endregion Properties

        #region Collections
        ObservableCollection<ISpeciality> Specialities { get; }
        #endregion
    }

    public class UserViewModel : ViewModelBase, IUserViewModel
    {
        #region Constructors
        public UserViewModel(IWorker worker)
        {
            WorkerId = worker.WorkerId;
            LastName = worker.LastName;
            FirstName = worker.FirstName;
            MiddleName = worker.MiddleName;
            DateOfBirth = worker.DateOfBirth;
            PassportNumber = worker.PassportNumber;
            WorkbookNumber = worker.WorkbookNumber;
            MedicalbookNumber = worker.MedicalbookNumber;
            IdNumber = worker.IdNumber;
            PhoneNumber = worker.PhoneNumber;
            Address = worker.Address;
            Position = worker.Position;
            Salon = worker.Salon;
            LoginName = worker.LoginName;
            Status = worker.Status;
            Specialities = new ObservableCollection<ISpeciality>(worker.Specialities);

            Order = new OrderViewModel(this);
            Worker = new WorkerViewModel();
            Schedule = new ScheduleViewModel(this);
        }
        #endregion

        #region Properties
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }

            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

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

        private long _idNumber;
        public long IdNumber
        {
            get
            {
                return _idNumber;
            }

            set
            {
                _idNumber = value;
                OnPropertyChanged("IdNumber");
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

        public string LoginName
        {
            get;
        }

        private int _medicalbookNumber;
        public int MedicalbookNumber
        {
            get
            {
                return _medicalbookNumber;
            }

            set
            {
                _medicalbookNumber = value;
                OnPropertyChanged("MedicalbookNumber");
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get
            {
                return _middleName;
            }

            set
            {
                _middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        private string _passportNumber;
        public string PassportNumber
        {
            get
            {
                return _passportNumber;
            }

            set
            {
                _passportNumber = value;
                OnPropertyChanged("PassportNumber");
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

        public IPosition Position
        {
            get;
        }

        public ISalon Salon
        {
            get;
        }

        public ObservableCollection<ISpeciality> Specialities
        {
            get;
        }

        public WorkerStatus Status
        {
            get;
        }

        private int _workbookNumber;
        public int WorkbookNumber
        {
            get
            {
                return _workbookNumber;
            }

            set
            {
                _workbookNumber = value;
                OnPropertyChanged("WorkbookNumber");
            }
        }
        public int WorkerId
        {
            get;
        }

        public IOrderViewModel Order
        {
            get;
        }

        public IWorkerViewModel Worker
        {
            get;
        }

        public IScheduleViewModel Schedule
        {
            get;
        }
        #endregion
    }
}
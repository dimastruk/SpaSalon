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
    public interface IWorkersViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IWorkerViewModel> Workers { get; set; }
        ObservableCollection<IWorkerViewModel> AllWorkers { get; }
        IWorkerViewModel SelectedWorker { get; set; }
        IWorkerViewModel NewWorker { get; set; }
        ObservableCollection<IPositionViewModel> AllPositions { get; }
        IPositionViewModel SelectedPosition { get; set; }
        IPositionViewModel NewSelectedPosition { get; set; }
        WorkerFilters WorkerFilter { get; set; }
        ICommand SearchWorkerCommand { get; }
        ICommand ChangeWorkerInfoCommand { get; }
        string SearchString { get; set; }
    }

    public class WorkersViewModel : ViewModelBase, IWorkersViewModel
    {
        public WorkersViewModel(int salonId)
        {
            var workersService = new WorkersService();
            var workers = workersService.GetWorkers(salonId);

            AllWorkers = new ObservableCollection<IWorkerViewModel>();

            foreach(var worker in workers)
            {
                AllWorkers.Add(new WorkerViewModel(worker));
            }

            Workers = AllWorkers;

            var positionService = new PositionService();
            var positions = positionService.GetPositions();

            AllPositions = new ObservableCollection<IPositionViewModel>();

            foreach(var position in positions)
            {
                AllPositions.Add(new PositionViewModel(position));
            }

            WorkerFilter = WorkerFilters.LastName;
        }

        private IWorkerViewModel _selectedWorker;
        public IWorkerViewModel SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }

            set
            {
                _selectedWorker = value;
                if (_selectedWorker != null)
                {
                    NewWorker = new WorkerViewModel();
                    NewWorker.LastName = _selectedWorker.LastName;
                    NewWorker.FirstName = _selectedWorker.FirstName;
                    NewWorker.MiddleName = _selectedWorker.MiddleName;
                    NewWorker.DateOfBirth = _selectedWorker.DateOfBirth;
                    NewWorker.PassportNumber = _selectedWorker.PassportNumber;
                    NewWorker.WorkbookNumber = _selectedWorker.WorkbookNumber;
                    NewWorker.MedicalbookNumber = _selectedWorker.MedicalbookNumber;
                    NewWorker.IdNumber = _selectedWorker.IdNumber;
                    NewWorker.PhoneNumber = _selectedWorker.PhoneNumber;
                    NewWorker.Address = _selectedWorker.Address;
                    NewWorker.Position = _selectedWorker.Position;

                    SelectedPosition = _selectedWorker.Position;

                    NewSelectedPosition = new PositionViewModel();
                    NewSelectedPosition.PositionName = _selectedPosition.PositionName;
                }
                else
                {
                    SelectedPosition = null;
                    NewSelectedPosition = null;
                    NewWorker = null;
                }
                OnPropertyChanged("SelectedWorker");
            }
        }

        private IWorkerViewModel _newWorker;
        public IWorkerViewModel NewWorker
        {
            get
            {
                return _newWorker;
            }
            set
            {
                _newWorker = value;
                OnPropertyChanged("NewWorker");
            }
        }

        private ObservableCollection<IWorkerViewModel> _workers;
        public ObservableCollection<IWorkerViewModel> Workers
        {
            get
            {
                return _workers;
            }
            set
            {
                _workers = value;
                OnPropertyChanged("Workers");
            }
        }

        public ObservableCollection<IWorkerViewModel> AllWorkers
        {
            get;
        }

        public ObservableCollection<IPositionViewModel> AllPositions
        {
            get;
        }

        private IPositionViewModel _selectedPosition;
        public IPositionViewModel SelectedPosition
        {
            get
            {
                return _selectedPosition;
            }

            set
            {
                _selectedPosition = value;
                OnPropertyChanged("SelectedPosition");
            }
        }

        private IPositionViewModel _newSelectedPosition;
        public IPositionViewModel NewSelectedPosition
        {
            get
            {
                return _newSelectedPosition;
            }

            set
            {
                _newSelectedPosition = value;
                OnPropertyChanged("NewSelectedPosition");
            }
        }

        WorkerFilters _workerFilter;
        public WorkerFilters WorkerFilter
        {
            get
            {
                return _workerFilter;
            }

            set
            {
                _workerFilter = value;
                OnPropertyChanged("WorkerFilter");
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
                    Workers = AllWorkers;
                }
                OnPropertyChanged("SearchString");
            }
        }

        private ICommand _searchWorkerCommand;
        public ICommand SearchWorkerCommand
        {
            get
            {
                if(_searchWorkerCommand == null)
                {
                    _searchWorkerCommand = new DelegateCommand(SearchWorkerCommand_Execute, SearchWorkerCommand_CanExecute);
                }

                return _searchWorkerCommand;
            }
        }

        private ICommand _changeWorkerInfoCommand;
        public ICommand ChangeWorkerInfoCommand
        {
            get
            {
                if(_changeWorkerInfoCommand == null)
                {
                    _changeWorkerInfoCommand = new DelegateCommand(ChangeWorkerInfoCommand_Execute, ChangeWorkerInfoCommand_CanExecute);
                }

                return _changeWorkerInfoCommand;
            }
        }

        private bool ChangeWorkerInfoCommand_CanExecute(object o)
        {
            if(NewWorker == null)
            {
                return false;
            }

            if(string.IsNullOrEmpty(NewWorker.LastName) || string.IsNullOrEmpty(NewWorker.FirstName) || string.IsNullOrEmpty(NewWorker.MiddleName) ||
                string.IsNullOrEmpty(NewWorker.PassportNumber.ToString()) || string.IsNullOrEmpty(NewWorker.WorkbookNumber.ToString()) ||
                string.IsNullOrEmpty(NewWorker.MedicalbookNumber.ToString()) || string.IsNullOrEmpty(NewWorker.IdNumber.ToString()) ||
                string.IsNullOrEmpty(NewWorker.PhoneNumber.ToString()) || string.IsNullOrEmpty(NewWorker.Address) ||
                NewSelectedPosition == null || string.IsNullOrEmpty(NewWorker.DateOfBirth))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ChangeWorkerInfoCommand_Execute(object o)
        {
            try
            {
                var workerService = new WorkersService();
                var positionService = new PositionService();

                NewWorker.Position.PositionName = NewSelectedPosition.PositionName;
                NewWorker.Position.PositionId = positionService.GetID(NewWorker.Position.PositionName);

                var selectedWorkerModel = new Worker(SelectedWorker.WorkerId, SelectedWorker.LastName, SelectedWorker.FirstName,
                    SelectedWorker.MiddleName, Convert.ToDateTime(SelectedWorker.DateOfBirth), SelectedWorker.PassportNumber, SelectedWorker.WorkbookNumber,
                    SelectedWorker.MedicalbookNumber, SelectedWorker.IdNumber, SelectedWorker.PhoneNumber, SelectedWorker.Address,
                    new Position(SelectedWorker.Position.PositionId, SelectedWorker.Position.PositionName));

                var newWorkerModel = new Worker(NewWorker.WorkerId, NewWorker.LastName, NewWorker.FirstName,
                    NewWorker.MiddleName, Convert.ToDateTime(NewWorker.DateOfBirth), NewWorker.PassportNumber, NewWorker.WorkbookNumber,
                    NewWorker.MedicalbookNumber, NewWorker.IdNumber, NewWorker.PhoneNumber, NewWorker.Address,
                    new Position(NewWorker.Position.PositionId, NewWorker.Position.PositionName));

                workerService.ChangeWorkerInfo(selectedWorkerModel, newWorkerModel);

                var worker = Workers.FirstOrDefault(w => w.WorkerId == SelectedWorker.WorkerId);
                worker.LastName = NewWorker.LastName;
                worker.FirstName = NewWorker.FirstName;
                worker.MiddleName = NewWorker.MiddleName;
                worker.DateOfBirth = NewWorker.DateOfBirth;
                worker.PassportNumber = NewWorker.PassportNumber;
                worker.WorkbookNumber = NewWorker.WorkbookNumber;
                worker.MedicalbookNumber = NewWorker.MedicalbookNumber;
                worker.IdNumber = NewWorker.IdNumber;
                worker.PhoneNumber = NewWorker.PhoneNumber;
                worker.Address = NewWorker.Address;
                worker.Position = NewWorker.Position;

                MessageBox.Show("Дані успішно змінено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }

        private bool SearchWorkerCommand_CanExecute(object o)
        {
            return !string.IsNullOrEmpty(SearchString);
        }

        private void SearchWorkerCommand_Execute(object o)
        {
            try
            {
                switch(WorkerFilter)
                {
                    case WorkerFilters.LastName:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.LastName == SearchString).ToList());
                        break;
                    case WorkerFilters.FirstName:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.FirstName == SearchString).ToList());
                        break;
                    case WorkerFilters.MiddleName:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.MiddleName == SearchString).ToList());
                        break;
                    case WorkerFilters.DateOfBirth:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.DateOfBirth == SearchString).ToList());
                        break;
                    case WorkerFilters.PassportNumber:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.PassportNumber == SearchString).ToList());
                        break;
                    case WorkerFilters.WorkbookNumber:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.WorkbookNumber.ToString() == SearchString).ToList());
                        break;
                    case WorkerFilters.MedicalbookNumber:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.MedicalbookNumber.ToString() == SearchString).ToList());
                        break;
                    case WorkerFilters.IdNumber:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.IdNumber.ToString() == SearchString).ToList());
                        break;
                    case WorkerFilters.PhoneNumber:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.PhoneNumber.ToString() == SearchString).ToList());
                        break;
                    case WorkerFilters.Address:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.Address == SearchString).ToList());
                        break;
                    case WorkerFilters.Position:
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.Position.PositionName == SearchString).ToList());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка!");
            }
        }
    }
}
using IssueTracker.Commands;
using Spa_salon.Common.Enumerations;
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
        ObservableCollection<IPositionViewModel> AllPositions { get; }
        IPositionViewModel SelectedPosition { get; set; }
        WorkerFilters WorkerFilter { get; set; }
        ICommand SearchWorkerCommand { get; }
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
                    SelectedPosition = _selectedWorker.Position;
                }
                else
                {
                    SelectedPosition = null;
                }
                OnPropertyChanged("SelectedWorker");
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
                        Workers = new ObservableCollection<IWorkerViewModel>(AllWorkers.Where(w => w.DateOfBirth.ToString("dd.MM.yyyy") == SearchString).ToList());
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
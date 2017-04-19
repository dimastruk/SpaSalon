using IssueTracker.Commands;
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
        ObservableCollection<IWorkerViewModel> Workers { get; }
        IWorkerViewModel SelectedWorker { get; set; }
        ObservableCollection<IPositionViewModel> AllPositions { get; }
        IPositionViewModel SelectedPosition { get; set; }
    }

    public class WorkersViewModel : ViewModelBase, IWorkersViewModel
    {
        public WorkersViewModel(int salonId)
        {
            var workersService = new WorkersService();
            var workers = workersService.GetWorkers(salonId);

            Workers = new ObservableCollection<IWorkerViewModel>();

            foreach(var worker in workers)
            {
                Workers.Add(new WorkerViewModel(worker));
            }

            var positionService = new PositionService();
            var positions = positionService.GetPositions();

            AllPositions = new ObservableCollection<IPositionViewModel>();

            foreach(var position in positions)
            {
                AllPositions.Add(new PositionViewModel(position));
            }
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
                SelectedPosition = _selectedWorker.Position;
                OnPropertyChanged("SelectedWorker");
            }
        }

        public ObservableCollection<IWorkerViewModel> Workers
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
    }
}
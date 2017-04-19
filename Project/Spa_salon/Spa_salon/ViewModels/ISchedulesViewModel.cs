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
    public interface ISchedulesViewModel : INotifyPropertyChanged
    {
        #region Properties
        #endregion
        IScheduleViewModel SelectedSchedule { get; set; }
        #region Collections
        ObservableCollection<IScheduleViewModel> AllWorkerSchedules { get; }
        ObservableCollection<IScheduleViewModel> ActualWorkerSchedules { get; }
        #endregion

        #region Commands
        #endregion
    }

    public class SchedulesViewModel : ViewModelBase, ISchedulesViewModel
    {
        #region Constructors
        public SchedulesViewModel(UserViewModel user)
        {
            var workersScheduleService = new WorkersScheduleService();
            AllWorkerSchedules = new ObservableCollection<IScheduleViewModel>();

            foreach(var schedule in workersScheduleService.GetWorkersSchedules(user.WorkerId))
            {
                AllWorkerSchedules.Add(new ScheduleViewModel(schedule));
            }

            ActualWorkerSchedules = new ObservableCollection<IScheduleViewModel>(AllWorkerSchedules.Where(s => s.IsActual == true));
        }

        public SchedulesViewModel(WorkerViewModel worker)
        {
            var workersScheduleService = new WorkersScheduleService();
            AllWorkerSchedules = new ObservableCollection<IScheduleViewModel>();

            foreach (var schedule in workersScheduleService.GetWorkersSchedules(worker.WorkerId))
            {
                AllWorkerSchedules.Add(new ScheduleViewModel(schedule));
            }

            ActualWorkerSchedules = new ObservableCollection<IScheduleViewModel>(AllWorkerSchedules.Where(s => s.IsActual == true));
        }
        #endregion

        #region Properties
        public ObservableCollection<IScheduleViewModel> AllWorkerSchedules
        {
            get;
        }

        public ObservableCollection<IScheduleViewModel> ActualWorkerSchedules
        {
            get;
        }

        private IScheduleViewModel _selectedSchedule;
        public IScheduleViewModel SelectedSchedule
        {
            get
            {
                return _selectedSchedule;
            }

            set
            {
                _selectedSchedule = value;
                OnPropertyChanged("SelectedSchedule");
            }
        }
        #endregion

        #region Commands
        #endregion
    }
}
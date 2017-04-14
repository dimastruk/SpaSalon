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
    public interface IScheduleViewModel : INotifyPropertyChanged
    {
        #region Properties
        #endregion

        #region Collections
        ObservableCollection<IWorkersSchedule> AllWorkerSchedules { get; }
        ObservableCollection<IWorkersSchedule> ActualWorkerSchedules { get; }
        #endregion

        #region Commands
        #endregion
    }

    public class ScheduleViewModel : ViewModelBase, IScheduleViewModel
    {
        #region Constructors
        public ScheduleViewModel(UserViewModel user)
        {
            var workersScheduleService = new WorkersScheduleService();
            AllWorkerSchedules = new ObservableCollection<IWorkersSchedule>(workersScheduleService.GetWorkersSchedules(user.WorkerId));
            ActualWorkerSchedules = new ObservableCollection<IWorkersSchedule>(AllWorkerSchedules.Where(s => s.IsActual == true));
        }
        #endregion

        #region Properties
        public ObservableCollection<IWorkersSchedule> AllWorkerSchedules
        {
            get;
        }

        public ObservableCollection<IWorkersSchedule> ActualWorkerSchedules
        {
            get;
        }
        #endregion

        #region Commands
        #endregion
    }
}

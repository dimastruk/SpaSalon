using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IScheduleViewModel : INotifyPropertyChanged
    {
        int WorkersScheduleId { get; }
        DateTime DateValue { get; set; }
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        bool IsActual { get; set; }
    }

    public class ScheduleViewModel : ViewModelBase, IScheduleViewModel
    {
        public ScheduleViewModel(IWorkersSchedule schedule)
        {
            WorkersScheduleId = schedule.WorkersScheduleId;
            DateValue = schedule.DateValue;
            StartTime = schedule.StartTime;
            EndTime = schedule.EndTime;
            IsActual = schedule.IsActual;
        }

        private DateTime _dateValue;
        public DateTime DateValue
        {
            get
            {
                return _dateValue;
            }

            set
            {
                _dateValue = value;
                OnPropertyChanged("DateValue");
            }
        }

        private TimeSpan _endTime;
        public TimeSpan EndTime
        {
            get
            {
                return _endTime;
            }

            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }

        private bool _isActual;
        public bool IsActual
        {
            get
            {
                return _isActual;
            }

            set
            {
                _isActual = value;
                OnPropertyChanged("IsActual");
            }
        }

        private TimeSpan _startTime;
        public TimeSpan StartTime
        {
            get
            {
                return _startTime;
            }

            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }

        public int WorkersScheduleId
        {
            get;
        }
    }
}

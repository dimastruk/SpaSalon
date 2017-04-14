using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IWorkersSchedule
    {
        int WorkersScheduleId { get; }
        DateTime DateValue { get; set; }
        TimeSpan StartTime { get; set; }
        TimeSpan EndTime { get; set; }
        bool IsActual { get; set; }
        IWorker Worker { get; set; }
    }

    public class WorkersSchedule : IWorkersSchedule
    {
        public WorkersSchedule(int workersScheduleId, DateTime dateValue, TimeSpan startTime,
            TimeSpan endTime, bool isActual, IWorker worker)
        {
            WorkersScheduleId = workersScheduleId;
            DateValue = dateValue;
            StartTime = startTime;
            EndTime = endTime;
            IsActual = isActual;
            Worker = worker;
        }

        public DateTime DateValue
        {
            get;
            set;
        }

        public TimeSpan EndTime
        {
            get;
            set;
        }

        public bool IsActual
        {
            get;
            set;
        }

        public TimeSpan StartTime
        {
            get;
            set;
        }

        public IWorker Worker
        {
            get;
            set;
        }

        public int WorkersScheduleId
        {
            get;
        }
    }
}
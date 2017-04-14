using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface ICalendar
    {
        DateTime DateValue { get; set; }
        string DayName { get; set; }
        string MonthName { get; set; }
        string DateYear { get; set; }
        byte DateDay { get; set; }
        short DayOfTheYear { get; set; }
        short DateMonth { get; set; }
        byte Quarter { get; set; }
        ICollection<IWorkersSchedule> WorkersSchedules { get; }
    }

    public class Calendar : ICalendar
    {
        public Calendar(DateTime dateValue, string dayName, string monthName,
            string dateYear, byte dateDay, short dayOfTheYear, short dateMonth, byte quarter)
        {
            DateValue = dateValue;
            DayName = dayName;
            MonthName = monthName;
            DateYear = dateYear;
            DateDay = dateDay;
            DayOfTheYear = dayOfTheYear;
            DateMonth = dateMonth;
            Quarter = quarter;

            var workersScheduleService = new WorkersScheduleService();
            WorkersSchedules = workersScheduleService.GetWorkersSchedules(this);
        }

        public byte DateDay
        {
            get;
            set;
        }

        public short DateMonth
        {
            get;
            set;
        }

        public DateTime DateValue
        {
            get;
            set;
        }

        public string DateYear
        {
            get;
            set;
        }

        public string DayName
        {
            get;
            set;
        }

        public short DayOfTheYear
        {
            get;
            set;
        }

        public string MonthName
        {
            get;
            set;
        }

        public byte Quarter
        {
            get;
            set;
        }

        public ICollection<IWorkersSchedule> WorkersSchedules
        {
            get;
        }
    }
}
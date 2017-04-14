using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using DbCalendar = DAL.DbModel.Calendar;
    public interface ICalendarService
    {
        ICalendar GetCalendar(DbCalendar calender);
    }

    public class CalendarService : DbDependentService, ICalendarService
    {
        public ICalendar GetCalendar(DbCalendar calender)
        {
            if(calender == null)
            {
                throw new ArgumentNullException("calendar");
            }

            var dbCalendar = DbService.Context.Calendar.FirstOrDefault(c => c.DateValue == calender.DateValue);

            return new Models.Calendar(dbCalendar.DateValue, dbCalendar.DayName, dbCalendar.MonthName, 
                dbCalendar.Date_Year, dbCalendar.Date_Day, dbCalendar.DayOfTheYear, dbCalendar.Date_Month, dbCalendar.Quarter);
        }
    }
}

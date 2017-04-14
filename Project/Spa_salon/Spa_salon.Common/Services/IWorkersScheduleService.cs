using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Workers_Schedule = DAL.DbModel.Workers_schedule;

    public interface IWorkersScheduleService
    {
        IWorkersSchedule GetWorkersSchedule(Workers_Schedule schedule);
        ICollection<IWorkersSchedule> GetWorkersSchedules(ICalendar calendar);
        ICollection<IWorkersSchedule> GetWorkersSchedules(int workerId);
    }

    public class WorkersScheduleService : DbDependentService, IWorkersScheduleService
    {
        public IWorkersSchedule GetWorkersSchedule(Workers_Schedule schedule)
        {
            if(schedule == null)
            {
                throw new ArgumentNullException("schedule");
            }

            var dbSchedule = DbService.Context.Workers_schedule.FirstOrDefault(s => s.workers_schedule_id == schedule.workers_schedule_id);

            var workersService = new WorkersService();
            var worker = workersService.GetWorker(DbService.Context.Workers.FirstOrDefault(w => w.worker_id == schedule.Workers.worker_id));

            return new WorkersSchedule(dbSchedule.workers_schedule_id, dbSchedule.DateValue, dbSchedule.start_time, dbSchedule.end_time, dbSchedule.isActual, worker);
        }

        public ICollection<IWorkersSchedule> GetWorkersSchedules(int workerId)
        {
            var list = new List<IWorkersSchedule>();

            var dbWorkersSchedules = DbService.Context.Workers_schedule.Where(s => s.worker_id == workerId);

            foreach (var dbWorkersSchedule in dbWorkersSchedules)
            {
                list.Add(GetWorkersSchedule(dbWorkersSchedule));
            }

            return list;
        }

        public ICollection<IWorkersSchedule> GetWorkersSchedules(ICalendar calendar)
        {
            if(calendar == null)
            {
                throw new ArgumentNullException("calendar");
            }

            var list = new List<IWorkersSchedule>();

            var dbWorkersSchedules = DbService.Context.Workers_schedule.Where(s => s.Calendar.DateValue == calendar.DateValue);

            foreach(var dbWorkersSchedule in dbWorkersSchedules)
            {
                list.Add(GetWorkersSchedule(dbWorkersSchedule));
            }

            return list;
        }
    }
}
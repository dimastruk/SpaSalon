using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Workers = DAL.DbModel.Workers;

    public interface IWorkersService
    {
        IWorker GetWorker(Workers worker);
        Workers GetWorker(IWorker worker);
        IWorker Login(string loginName, string password);
        void ChangePassword(IWorker worker, string oldPassword, string newPassword);
    }

    public class WorkersService : DbDependentService, IWorkersService
    {
        public void ChangePassword(IWorker worker, string oldPassword, string newPassword)
        {
            if(worker == null)
            {
                throw new ArgumentNullException("worker");
            }

            var dbWorker = DbService.Context.Workers.FirstOrDefault(w => w.worker_id == worker.WorkerId);

            if (!string.Equals(oldPassword, Encoding.UTF8.GetString(dbWorker.password_string)))
            {
                throw new ArgumentException("Старий пароль неправильний!");
            }

            dbWorker.password_string = Encoding.UTF8.GetBytes(newPassword);
            DbService.SaveChanges();
        }

        public Workers GetWorker(IWorker worker)
        {
            if(worker == null)
            {
                throw new ArgumentNullException("worker");
            }

            var dbWorker = DbService.Context.Workers.FirstOrDefault(w => w.worker_id == worker.WorkerId);
            if(dbWorker == null)
            {
                throw new NullReferenceException("Worker not found");
            }

            return dbWorker;
        }

        public IWorker GetWorker(Workers worker)
        {
            if (worker == null)
            {
                throw new ArgumentNullException("worker");
            }

            var position = new Position(worker.Positions.position_id, worker.Positions.position_name);
            var salon = new Salon(worker.Salons.salon_id, worker.Salons.address);

            return new Worker(worker.worker_id, worker.last_name, worker.first_name, worker.middle_name,
                worker.date_of_birth, worker.passport_number, worker.workbook_number, worker.medicalbook_number,
                worker.ID_number, worker.phone_number, worker.address, position, salon, worker.login_name);
        }

        public IWorker Login(string loginName, string password)
        {
            var workerdata = DbService.Context.Workers.FirstOrDefault(w => w.login_name.Equals(loginName));
            if (workerdata != null)
            {
                var decryptedPassword = Encoding.UTF8.GetString(workerdata.password_string);
                if (string.CompareOrdinal(decryptedPassword, password) == 0)
                {
                    return GetWorker(workerdata);
                }
                throw new InvalidOperationException("Неправильний пароль для цього користувача!");
            }
            throw new InvalidOperationException("Даний користувач не існує!");
        }
    }
}
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
        ICollection<IWorker> GetWorkers(int salonId);
        IWorker Login(string loginName, string password);
        void ChangePassword(IWorker worker, string oldPassword, string newPassword);
        void ChangeWorkerInfo(IWorker currentWorker, IWorker newWorker);
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

        public void ChangeWorkerInfo(IWorker currentWorker, IWorker newWorker)
        {
            if(currentWorker == null)
            {
                throw new ArgumentNullException("currentWorker");
            }

            if(newWorker == null)
            {
                throw new ArgumentNullException("newWorker");
            }

            var dbWorkers = DbService.Context.Workers;

            foreach(var worker in dbWorkers)
            {
                if(worker.worker_id == currentWorker.WorkerId)
                {
                    continue;
                }

                if(worker.ID_number == newWorker.IdNumber)
                {
                    throw new Exception("Даний ідентифікаційний номер вже внесений в базу!");
                }

                if(worker.medicalbook_number == newWorker.MedicalbookNumber)
                {
                    throw new Exception("Даний номер медичної картки вже внесений в базу!");
                }

                if(worker.passport_number == newWorker.PassportNumber)
                {
                    throw new Exception("Даний номер паспорту вже внесений в базу!");
                }

                if(worker.phone_number == newWorker.PhoneNumber)
                {
                    throw new Exception("Даний номер телефону вже внесений в базу!");
                }

                if(worker.workbook_number == newWorker.WorkbookNumber)
                {
                    throw new Exception("Даний номер трудової книги вже внесений в базу!");
                }
            }

            var dbWorker = DbService.Context.Workers.FirstOrDefault(w => w.worker_id == currentWorker.WorkerId);

            dbWorker.last_name = newWorker.LastName;
            dbWorker.first_name = newWorker.FirstName;
            dbWorker.middle_name = newWorker.MiddleName;
            dbWorker.date_of_birth = newWorker.DateOfBirth;
            dbWorker.passport_number = newWorker.PassportNumber;
            dbWorker.workbook_number = newWorker.WorkbookNumber;
            dbWorker.medicalbook_number = newWorker.MedicalbookNumber;
            dbWorker.ID_number = newWorker.IdNumber;
            dbWorker.phone_number = newWorker.PhoneNumber;
            dbWorker.address = newWorker.Address;
            dbWorker.position_id = newWorker.Position.PositionId;

            //var positionService = new PositionService();
            //dbWorker.Positions = positionService.GetPosition(new Position(newWorker.Position.PositionId, newWorker.Position.PositionName));

            DbService.Context.SaveChanges();
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

        public ICollection<IWorker> GetWorkers(int salonId)
        {
            var list = new List<IWorker>();

            var workers = DbService.Context.Workers.Where(w => w.salon_id == salonId);

            foreach(var worker in workers)
            {
                list.Add(GetWorker(worker));
            }

            return list;
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
using Spa_salon.Common.Enumerations;
using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IWorker
    {
        int WorkerId { get; }
        string LastName { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        DateTime DateOfBirth { get; set; }
        string PassportNumber { get; set; }
        int WorkbookNumber { get; set; }
        int MedicalbookNumber { get; set; }
        long IdNumber { get; set; }
        long PhoneNumber { get; set; }
        string Address { get; set; }
        IPosition Position { get; }
        ISalon Salon { get; }
        string LoginName { get; }
        WorkerStatus Status { get; }
        ICollection<ISpeciality> Specialities { get; }
    }

    public class Worker : IWorker
    {
        public Worker(int workerId, string lastName, string firstName, string middleName, DateTime dateOfBirth, 
            string passportNumber, int workbookNumber, int medicalbookNumber, long idNumber, long phoneNumber,
            string address, IPosition position, ISalon salon, string loginName)
        {
            WorkerId = workerId;
            LastName = lastName.Trim();
            FirstName = firstName.Trim();
            MiddleName = middleName.Trim();
            DateOfBirth = dateOfBirth;
            PassportNumber = passportNumber;
            WorkbookNumber = workbookNumber;
            MedicalbookNumber = medicalbookNumber;
            IdNumber = idNumber;
            PhoneNumber = phoneNumber;
            Address = address;
            Position = position;
            Salon = salon;
            LoginName = loginName;

            if(String.Equals(Position.PositionName, EnumHelper.GetEnumDescription(WorkerStatus.Owner)))
            {
                Status = WorkerStatus.Owner;
            }
            else if (String.Equals(Position.PositionName, EnumHelper.GetEnumDescription(WorkerStatus.Administrator)))
            {
                Status = WorkerStatus.Administrator;
            }
            else
            {
                Status = WorkerStatus.Worker;
            }

            var specialitiesService = new SpecialitiesService();
            Specialities = specialitiesService.GetSpecialities(WorkerId);
        }

        public string Address
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public long IdNumber
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string LoginName
        {
            get;
        }

        public int MedicalbookNumber
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string PassportNumber
        {
            get;
            set;
        }

        public long PhoneNumber
        {
            get;
            set;
        }

        public IPosition Position
        {
            get;
        }

        public ISalon Salon
        {
            get;
        }

        public ICollection<ISpeciality> Specialities
        {
            get;
        }

        public WorkerStatus Status
        {
            get;
        }

        public int WorkbookNumber
        {
            get;
            set;
        }

        public int WorkerId
        {
            get;
        }
    }
}
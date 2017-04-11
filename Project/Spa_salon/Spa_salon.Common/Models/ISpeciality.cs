using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface ISpeciality
    {
        int SpecialityId { get; }
        IWorker Worker { get; set; }
        IService Service { get; set; }
        int Commisions { get; set; }
    }

    public class Speciality : ISpeciality
    {
        public Speciality(int specialityId, IWorker worker, IService service, int commisions)
        {
            SpecialityId = specialityId;
            Worker = worker;
            Service = service;
            Commisions = commisions;
        }

        public Speciality(int specialityId, IService service, int commisions)
        {
            SpecialityId = specialityId;
            Service = service;
            Commisions = commisions;
        }

        public int Commisions
        {
            get;
            set;
        }

        public IService Service
        {
            get;
            set;
        }

        public int SpecialityId
        {
            get;
        }

        public IWorker Worker
        {
            get;
            set;
        }
    }
}
using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using DAL.DbModel;
    using Specialities = DAL.DbModel.Specialities;

    public interface ISpecialitiesService
    {
        ICollection<ISpeciality> GetSpecialities(int workerId);
        ISpeciality GetSpeciality(Specialities speciality);
    }

    public class SpecialitiesService : DbDependentService, ISpecialitiesService
    {
        public ICollection<ISpeciality> GetSpecialities(int workerId)
        {
            var specialities = DbService.Context.Specialities.Where(w => w.worker_id == workerId);

            var list = new List<ISpeciality>();

            foreach(var speciality in specialities)
            {
                list.Add(GetSpeciality(speciality));
            }

            return list;
        }

        public ISpeciality GetSpeciality(Specialities speciality)
        {
            if(speciality == null)
            {
                throw new ArgumentNullException();
            }

            var servicesService = new ServicesService();
            var service = servicesService.GetService(DbService.Context.Services.FirstOrDefault(s => s.service_id == speciality.service_id));

            return new Speciality(speciality.speciality_id, service, speciality.commisions);
        }
    }
}
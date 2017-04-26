using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Salons = DAL.DbModel.Salons;

    public interface ISalonService
    {
        ISalon GetSalon(Salons salon);
        ICollection<ISalon> GetSalons();
    }

    public class SalonService : DbDependentService, ISalonService
    {
        public ISalon GetSalon(Salons salon)
        {
            if(salon == null)
            {
                throw new ArgumentNullException("salon");
            }

            return new Salon(salon.salon_id, salon.address);
        }

        public ICollection<ISalon> GetSalons()
        {
            var list = new List<ISalon>();

            var dbSalons = DbService.Context.Salons;

            foreach (var salon in dbSalons)
            {
                list.Add(GetSalon(salon));
            }

            return list;
        }
    }
}

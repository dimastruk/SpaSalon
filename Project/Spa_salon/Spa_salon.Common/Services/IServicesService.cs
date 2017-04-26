using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Services = DAL.DbModel.Services;
    public interface IServicesService
    {
        IService GetService(Services service);
        ICollection<IService> GetServices();
    }

    public class ServicesService : DbDependentService, IServicesService
    {
        public IService GetService(Services service)
        {
            if(service == null)
            {
                throw new ArgumentNullException();
            }

            return new Service(service.service_id, service.service_name, service.service_price);
        }

        public ICollection<IService> GetServices()
        {
            var list = new List<IService>();

            var dbServices = DbService.Context.Services;

            foreach(var service in dbServices)
            {
                list.Add(GetService(service));
            }

            return list;
        }
    }
}

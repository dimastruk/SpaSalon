using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IService
    {
        int ServiceID { get; }
        string ServiceName { get; set; }
        int ServicePrice { get; set; }
    }

    public class Service : IService
    {
        public Service(int serviceId, string serviceName, int servicePrice)
        {
            ServiceID = serviceId;
            ServiceName = serviceName;
            ServicePrice = servicePrice;
        }

        public int ServiceID
        {
            get;
        }

        public string ServiceName
        {
            get;
            set;
        }

        public int ServicePrice
        {
            get;
            set;
        }
    }
}
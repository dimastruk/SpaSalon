using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface ISalon
    {
        int SalodId { get; }
        string Address { get; set; }
    }

    public class Salon : ISalon
    {
        public Salon(int salonId, string address)
        {
            SalodId = salonId;
            Address = address;
        }

        public string Address
        {
            get;
            set;
        }

        public int SalodId
        {
            get;
        }
    }
}
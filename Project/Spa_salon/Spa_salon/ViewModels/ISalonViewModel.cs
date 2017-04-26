using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface ISalonViewModel : INotifyPropertyChanged
    {
        int SalonId { get; }
        string Address { get; set; }
    }

    public class SalonViewModel : ViewModelBase, ISalonViewModel
    {
        public SalonViewModel(int salonId, string address)
        {
            SalonId = salonId;
            Address = address;
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        public int SalonId
        {
            get;
        }
    }
}

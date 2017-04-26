using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IServiceViewModel : INotifyPropertyChanged
    {
        int ServiceID { get; }
        string ServiceName { get; set; }
        int ServicePrice { get; set; }
    }

    public class ServiceViewModel : ViewModelBase, IServiceViewModel
    {
        public ServiceViewModel(int serviceId, string serviceName, int servicePrice)
        {
            ServiceID = serviceId;
            ServiceName = serviceName;
            ServicePrice = servicePrice;
        }

        public int ServiceID
        {
            get;
        }

        private string _serviceName;
        public string ServiceName
        {
            get
            {
                return _serviceName;
            }

            set
            {
                _serviceName = value;
                OnPropertyChanged("ServiceName");
            }
        }

        private int _servicePrice;
        public int ServicePrice
        {
            get
            {
                return _servicePrice;
            }

            set
            {
                _servicePrice = value;
                OnPropertyChanged("ServicePrice");
            }
        }
    }
}
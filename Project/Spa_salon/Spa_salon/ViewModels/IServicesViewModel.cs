using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IServicesViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IServiceViewModel> Services { get; }
    }

    public class ServicesViewModel : ViewModelBase, IServicesViewModel
    {
        public ServicesViewModel()
        {
            var servicesService = new ServicesService();

            Services = new ObservableCollection<IServiceViewModel>();

            foreach(var service in servicesService.GetServices())
            {
                Services.Add(new ServiceViewModel(service.ServiceID, service.ServiceName, service.ServicePrice));
            }
        }

        public ObservableCollection<IServiceViewModel> Services
        {
            get;
        }
    }
}

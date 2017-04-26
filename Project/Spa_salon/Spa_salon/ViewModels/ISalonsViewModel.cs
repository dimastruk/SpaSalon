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
    public interface ISalonsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<ISalonViewModel> Salons { get; }
    }

    public class SalonsViewModel : ViewModelBase, ISalonsViewModel
    {
        public SalonsViewModel()
        {
            var salonService = new SalonService();

            Salons = new ObservableCollection<ISalonViewModel>();

            foreach(var salon in salonService.GetSalons())
            {
                Salons.Add(new SalonViewModel(salon.SalodId, salon.Address));
            }
        }

        public ObservableCollection<ISalonViewModel> Salons
        {
            get;
        }
    }
}
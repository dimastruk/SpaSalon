using Spa_salon.Common.Enumerations;
using Spa_salon.Common.Models;
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
    public interface IMainViewModel : INotifyPropertyChanged
    {
        IUserViewModel User { get; }
    }

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IWorker worker)
        {
            User = new UserViewModel(worker);
        }

        public IUserViewModel User
        {
            get;
        }
    }
}
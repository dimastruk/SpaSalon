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
        IWorkerViewModel Worker { get; }
    }

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IWorker worker)
        {
            Worker = new WorkerViewModel(worker);
        }

        public ISpeciality Speciality
        {
            get;
        }

        public WorkerStatus Status
        {
            get;
        }

        public IWorkerViewModel Worker
        {
            get;
        }
    }
}
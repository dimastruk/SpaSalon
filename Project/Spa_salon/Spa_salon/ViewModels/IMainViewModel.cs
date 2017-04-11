using Spa_salon.Common.Enumerations;
using Spa_salon.Common.Models;
using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IMainViewModel : INotifyPropertyChanged
    {
        IWorker Worker { get; }
    }

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public MainViewModel(IWorker worker)
        {
            Worker = worker;
        }

        public ISpeciality Speciality
        {
            get;
        }

        public WorkerStatus Status
        {
            get;
        }

        public IWorker Worker
        {
            get;
        }
    }
}
using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IWorkerViewModel : INotifyPropertyChanged
    {
        IWorker Model { get; }
    }

    public class WorkerViewModel : ViewModelBase, IWorkerViewModel
    {
        public WorkerViewModel(IWorker worker)
        {
            Model = worker;
        }

        public IWorker Model
        {
            get;
        }
    }
}

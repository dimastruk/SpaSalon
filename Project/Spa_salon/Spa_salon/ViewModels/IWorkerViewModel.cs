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
        //int WorkerId { get; }
        //string LastName { get; set; }
        //string FirstName { get; set; }
        //string MiddleName { get; set; }
        //DateTime DateOfBirth { get; set; }
        //string PassportNumber { get; set; }
        //int WorkbookNumber { get; set; }
        //int MedicalbookNumber { get; set; }
        //long IdNumber { get; set; }
        //long PhoneNumber { get; set; }
        //string Address { get; set; }
        //IPosition Position { get; }
        //ISalon Salon { get; }
        //string LoginName { get; }
        //WorkerStatus Status { get; }
        //ICollection<ISpeciality> Specialities { get; }
    }

    public class WorkerViewModel : ViewModelBase, IWorkerViewModel
    {

    }
}

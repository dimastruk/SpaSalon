using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.ViewModels
{
    public interface IPositionViewModel : INotifyPropertyChanged
    {
        int PositionId { get; set; }
        string PositionName { get; set; }
    }

    public class PositionViewModel : ViewModelBase, IPositionViewModel
    {
        public PositionViewModel()
        {

        }

        public PositionViewModel(IPosition position)
        {
            PositionId = position.PositionId;
            PositionName = position.PositionName;
        }

        public int PositionId
        {
            get;
            set;
        }

        private string _positionName;
        public string PositionName
        {
            get
            {
                return _positionName;
            }
            set
            {
                _positionName = value;
                OnPropertyChanged("PositionName");
            }
        }
    }
}
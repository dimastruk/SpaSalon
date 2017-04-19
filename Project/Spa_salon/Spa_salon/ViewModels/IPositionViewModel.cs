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
        int PositionId { get; }
        string PositionName { get; set; }
    }

    public class PositionViewModel : ViewModelBase, IPositionViewModel
    {
        public PositionViewModel(IPosition position)
        {
            PositionId = position.PositionId;
            PositionName = position.PositionName;
        }

        public int PositionId
        {
            get;
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
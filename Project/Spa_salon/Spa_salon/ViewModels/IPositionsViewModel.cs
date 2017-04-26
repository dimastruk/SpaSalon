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
    public interface IPositionsViewModel : INotifyPropertyChanged
    {
        ObservableCollection<IPositionViewModel> Positions { get; }
    }

    public class PositionsViewModel : ViewModelBase, IPositionsViewModel
    {
        public PositionsViewModel()
        {
            var positionService = new PositionService();

            Positions = new ObservableCollection<IPositionViewModel>();

            foreach(var position in positionService.GetPositions())
            {
                Positions.Add(new PositionViewModel(new Position(position.PositionId, position.PositionName)));
            }
        }

        public ObservableCollection<IPositionViewModel> Positions
        {
            get;
        }
    }
}

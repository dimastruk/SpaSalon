using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    public interface IPositionService
    {
        ICollection<IPosition> GetPositions();
    }

    public class PositionService : DbDependentService, IPositionService
    {
        public ICollection<IPosition> GetPositions()
        {
            var list = new List<IPosition>();

            var positions = DbService.Context.Positions;

            foreach(var position in positions)
            {
                list.Add(new Position(position.position_id, position.position_name));
            }

            return list;
        }
    }
}

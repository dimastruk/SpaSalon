using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Positions = DAL.DbModel.Positions;
    public interface IPositionService
    {
        Positions GetPosition(IPosition position);
        int GetID(string positionName);
        ICollection<IPosition> GetPositions();
    }

    public class PositionService : DbDependentService, IPositionService
    {
        public int GetID(string positionName)
        {
            var position = DbService.Context.Positions.FirstOrDefault(p => p.position_name == positionName);

            return position.position_id;
        }

        public Positions GetPosition(IPosition position)
        {
            if(position == null)
            {
                throw new ArgumentNullException("position");
            }

            var dbPosition = DbService.Context.Positions.FirstOrDefault(p => p.position_id == position.PositionId);

            return dbPosition;
        }

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

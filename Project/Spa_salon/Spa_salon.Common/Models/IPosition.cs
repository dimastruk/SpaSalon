using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IPosition
    {
        int PositionId { get; }
        string PositionName { get; set; }
    }

    public class Position : IPosition
    {
        public Position(int positionId, string positionName)
        {
            PositionId = positionId;
            PositionName = positionName.Trim();
        }

        public int PositionId
        {
            get;
        }

        public string PositionName
        {
            get;
            set;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    public abstract class DbDependentService
    {
        private readonly IDbService _dbService;

        protected DbDependentService()
        {
            _dbService = new DbService();
        }

        protected IDbService DbService
        {
            get { return _dbService; }
        }
    }
}

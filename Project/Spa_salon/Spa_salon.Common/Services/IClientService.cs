using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using Models;
    using DAL.DbModel;
    using Clients = DAL.DbModel.Clients;
    public interface IClientService
    {
        IClient GetClient(Clients client);
    }

    public class ClientService : DbDependentService, IClientService
    {
        public IClient GetClient(Clients client)
        {
            if(client == null)
            {
                throw new ArgumentNullException("client");
            }

            return new Client(client.client_id, client.last_name, client.first_name, client.phone_number);
        }
    }
}

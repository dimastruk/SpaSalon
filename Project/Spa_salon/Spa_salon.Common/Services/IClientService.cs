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
        ICollection<IClient> GetClients();
        void ChangeClientInfo(IClient client, string newLastName, string newFirstName, string newPhoneNumber);
        void AddClient(string lastName, string firstName, string phoneNumber);
    }

    public class ClientService : DbDependentService, IClientService
    {
        public void AddClient(string lastName, string firstName, string phoneNumber)
        {
            var newClient = new Clients { last_name = lastName, first_name = firstName, phone_number = long.Parse(phoneNumber) };

            var clients = DbService.Context.Clients;

            foreach(var client in clients)
            {
                if(client.last_name.Trim() == newClient.last_name && client.first_name.Trim() == newClient.first_name && client.phone_number == newClient.phone_number)
                {
                    throw new ArgumentException("Даний клієнт існує у базі!");
                }
            }

            DbService.Context.Clients.Add(newClient);
            DbService.SaveChanges();
        }

        public void ChangeClientInfo(IClient client, string newLastName, string newFirstName, string newPhoneNumber)
        {
            if(client == null)
            {
                throw new ArgumentNullException("client");
            }

            if((string.IsNullOrEmpty(newLastName)) || (string.IsNullOrEmpty(newFirstName)) || (string.IsNullOrEmpty(newPhoneNumber)))
            {
                throw new ArgumentNullException("Неправильні вхідні дані! Спробуйте ще раз!");
            }

            var DbClient = DbService.Context.Clients.FirstOrDefault(cl => cl.client_id == client.ClientId);
            
            if(DbClient == null)
            {
                throw new Exception("Даний клієнт не існує!");
            }

            var clients = DbService.Context.Clients;

            foreach (var dbClient in clients)
            {
                if (dbClient.last_name.Trim() == newLastName && dbClient.first_name.Trim() == newFirstName && dbClient.phone_number.ToString() == newPhoneNumber);
                {
                    throw new ArgumentException("Даний клієнт існує у базі!");
                }
            }

            DbClient.last_name = newLastName;
            DbClient.first_name = newFirstName;
            DbClient.phone_number = long.Parse(newPhoneNumber);

            client.LastName = newLastName;
            client.FirstName = newFirstName;
            client.PhoneNumber = long.Parse(newPhoneNumber);

            DbService.Context.SaveChanges();
        }

        public IClient GetClient(Clients client)
        {
            if(client == null)
            {
                throw new ArgumentNullException("client");
            }

            return new Client(client.client_id, client.last_name, client.first_name, client.phone_number);
        }

        public ICollection<IClient> GetClients()
        {
            var list = new List<IClient>();

            var clients = DbService.Context.Clients;

            foreach(var client in clients)
            {
                list.Add(GetClient(client));
            }

            return list;
        }
    }
}

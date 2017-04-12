﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IClient
    {
        int ClientId { get; }
        string LastName { get; }
        string FirstName { get; }
        long PhoneNumber { get; }
    }

    public class Client : IClient
    {
        public Client(int clientId, string lastName, string firstName, long phoneNumber)
        {
            ClientId = clientId;
            LastName = lastName.Trim();
            FirstName = firstName.Trim();
            PhoneNumber = phoneNumber;
        }

        public int ClientId
        {
            get;
        }

        public string FirstName
        {
            get;
        }

        public string LastName
        {
            get;
        }

        public long PhoneNumber
        {
            get;
        }
    }
}

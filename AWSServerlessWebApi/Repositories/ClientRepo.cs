﻿using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Repositories
{
    public class ClientRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public ClientRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public AccountBase CreateClient(ClientVM clientVM)
        {
            AccountBase client = new AccountBase()
            {
                AccountId = Guid.NewGuid(),
                Name = clientVM.ClientName,
                DeletionStateCode = clientVM.DeletionStateCode,
                StateCode = clientVM.StateCode

            };
            _context.AccountBase.Add(client);
            _context.SaveChanges();

            return client;
        }

        public List<AccountBase> GetAllClients()
        {
            return _context.AccountBase.ToList();
        }

        public AccountBase GetOneClient(Guid id)
        {
            return _context.AccountBase.Where(i => i.AccountId == id).FirstOrDefault();
        }
        public void UpdateOneClient(ClientVM clientVM)
        {
            Guid clientGuid = Guid.Parse(clientVM.ClientId);
            AccountBase client = _context.AccountBase.Where(i => i.AccountId == clientGuid).FirstOrDefault();
            client.Name = clientVM.ClientName;

            _context.SaveChanges();
        }

        public void DeleteOneClient(Guid id)
        {
            AccountBase client = _context.AccountBase.Where(i => i.AccountId == id).FirstOrDefault();
            _context.AccountBase.Remove(client);
            _context.SaveChanges();
        }
    }
}

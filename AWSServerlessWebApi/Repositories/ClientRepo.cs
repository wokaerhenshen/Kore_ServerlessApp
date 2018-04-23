using AWSServerlessWebApi.Models;
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

        public void CreateClient(ClientVM clientVM)
        {
            AccountBase client = new AccountBase()
            {
                Name = clientVM.ClientName,
                DeletionStateCode = clientVM.DeletionStateCode,
                StateCode = clientVM.StateCode

            };
            _context.AccountBase.Add(client);
            _context.SaveChanges();
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
            AccountBase client = _context.AccountBase.Where(i => i.AccountId == clientVM.ClientId).FirstOrDefault();
            client.Name = clientVM.ClientName;
            client.DeletionStateCode = clientVM.DeletionStateCode;
            client.StateCode = clientVM.StateCode;
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

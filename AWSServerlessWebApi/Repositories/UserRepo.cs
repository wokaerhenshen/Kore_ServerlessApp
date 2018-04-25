using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Repositories
{
    public class UserRepo
    {
        KORE_Interactive_MSCRMContext _context;

        public UserRepo(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public void CreateUser(UserVM userVM)
        {
            User user = new User()
            {
                UserId = Guid.NewGuid(),
                Email = userVM.Email,
                Password = userVM.Password,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetOneUser(Guid id)
        {
            return _context.Users.Where(i => i.UserId == id).FirstOrDefault();
        }

        public void UpdateOneUser(UserVM userVM)
        {

            User user = _context.Users.Where(i => i.UserId == Guid.Parse(userVM.UserId)).FirstOrDefault();

            user.Email = userVM.Email;
            user.Password = userVM.Password;
            user.FirstName = userVM.FirstName;
            user.LastName = userVM.LastName;

            _context.SaveChanges();
        }

        public void DeleteOneUser(Guid id)
        {
            User user = _context.Users.Where(i => i.UserId == id).FirstOrDefault();

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}

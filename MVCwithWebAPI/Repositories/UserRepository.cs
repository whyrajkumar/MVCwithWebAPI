using MVCwithWebAPI.Data;
using MVCwithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDbContext _dbContext;

        public UserRepository(SqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsValidUser(string username, string password)
        {
            return _dbContext.Users
                .Any(u => u.UserName.ToLower() == username.ToLower() && u.Password == password);
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
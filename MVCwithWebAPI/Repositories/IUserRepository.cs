using MVCwithWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Repositories
{
    public interface IUserRepository
    {
        bool IsValidUser(string username, string password);
        void AddUser(User user);
    }
}
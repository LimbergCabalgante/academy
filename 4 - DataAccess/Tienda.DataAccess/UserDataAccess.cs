using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Interfaces;

namespace Tienda.DataAccess
{
    class UserDataAccess : IUserLogic
    {
        private List<User> Users { get; }

        public UserDataAccess()
        {
            Users = new List<User>();
        }

        public void CreateUser(User user)
        {
            Users.Add(user);
        }
    }
}

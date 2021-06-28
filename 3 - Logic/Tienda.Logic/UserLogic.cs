using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Dapper;
using Tienda.Interfaces;

namespace Tienda.Logic
{
    public class UserLogic : IUserLogic
    {
        public IUserLogic dataAccess { get; }

        public UserLogic()
        {
            this.dataAccess = new UserDapper();
        }

        public void CreateUser(User user)
        {
            this.dataAccess.CreateUser(user);
        }
    }
}

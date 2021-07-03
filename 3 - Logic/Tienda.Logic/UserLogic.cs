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
        public IUserLogic DataAccess { get; }

        public UserLogic()
        {
            this.DataAccess = new UserDapper();
        }

        public void CreateUser(User user)
        {
            this.DataAccess.CreateUser(user);
        }
    }
}

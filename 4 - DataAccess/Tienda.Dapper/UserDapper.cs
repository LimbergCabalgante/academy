using Dapper;
using Dtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Interfaces;

namespace Tienda.Dapper
{
    public class UserDapper : IUserLogic
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=TiendaV2;Integrated Security=True";

        public void CreateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO dbo.Users (Name, Surname, DocumentNumber, Birthdate, CreatedDate, Email, Username, Password, StatusId) VALUES (@Name, @Surname, @DocumentNumber, @BirthDate, @CreatedDate, @Email, @Username, @Password, @StatusId)",
                    new
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        DocumentNumber = user.DocumentNumber,
                        Birthdate = user.Birthdate,
                        CreatedDate = DateTime.Now,
                        Email = user.Email,
                        Username = user.Username,
                        Password = user.Password,
                        StatusId = 1
                    });
            }
        }
    }
}

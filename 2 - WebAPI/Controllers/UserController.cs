using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tienda.Interfaces;

namespace Tienda.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] User user, [FromServices] IUserLogic userLogic)
        {
            userLogic.CreateUser(new User
            {
                Name = user.Name,
                Surname = user.Surname,
                DocumentNumber = user.DocumentNumber,
                Birthdate = user.Birthdate,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            });
            return Ok();
        }
    }
}

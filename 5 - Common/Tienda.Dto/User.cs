using System;

namespace Dtos
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

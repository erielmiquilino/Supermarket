using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Dtos.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }

        public DateTime InsertDate { get; set; }
    }
}

using System;

namespace Supermarket.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime InsertDate { get; set; }
    }
}

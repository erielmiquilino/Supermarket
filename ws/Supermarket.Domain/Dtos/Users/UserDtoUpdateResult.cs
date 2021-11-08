using System;

namespace Supermarket.Domain.Dtos.Users
{
    public class UserDtoUpdateResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}

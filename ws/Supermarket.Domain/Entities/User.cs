using Supermarket.Domain.Entities.Base;
using System;

namespace Supermarket.Domain.Entities
{
    public class User : BaseEntity
    {
        public String Name { get; set; }

        public String Email { get; set; }

        public String Password { get; set; }
    }

}
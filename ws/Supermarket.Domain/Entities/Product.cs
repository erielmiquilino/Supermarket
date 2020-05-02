using Supermarket.Domain.Entities.Base;
using System;

namespace Supermarket.Entities.Models
{
    public class Product : BaseEntity
    {
        public String Description { get; set; }
    }
}

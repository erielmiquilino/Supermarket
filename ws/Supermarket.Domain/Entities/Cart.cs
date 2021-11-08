using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Base;

namespace Supermarket.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public string Place { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}

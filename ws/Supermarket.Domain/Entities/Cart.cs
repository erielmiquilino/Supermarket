using System;
using System.Collections.Generic;
using Supermarket.Domain.Entities.Base;

namespace Supermarket.Domain.Entities
{
    public abstract class Cart : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public string Place { get; set; }

        public List<CartItem> CartItemList { get; set; }
    }
}

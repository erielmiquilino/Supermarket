using Supermarket.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Supermarket.Entities.Models
{
    public class Cart : BaseEntity
    {
        public DateTime PurchaseDate { get; set; }

        public String Place { get; set; }

        public List<CartItem> CartItemList { get; set; }
    }
}

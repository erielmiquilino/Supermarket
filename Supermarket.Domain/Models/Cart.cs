using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Models
{
    public class Cart
    {
        public DateTime PurchaseDate { get; set; }

        public String Place { get; set; }

        public List<CartItem> CartItemList { get; set; }
    }
}

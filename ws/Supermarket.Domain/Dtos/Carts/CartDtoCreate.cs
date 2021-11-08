using System;

namespace Supermarket.Domain.Dtos.Carts
{
    public class CartDtoCreate
    {
        public DateTime PurchaseDate { get; set; }

        public string Place { get; set; }
    }
}

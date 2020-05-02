using Supermarket.Domain.Entities.Base;
using System;

namespace Supermarket.Entities.Models
{
    public class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }

        public virtual Product product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalValue { get; set; }

        public Guid CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
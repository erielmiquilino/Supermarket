using System;
using Supermarket.Domain.Entities.Base;

namespace Supermarket.Domain.Entities
{
    public abstract class CartItem : BaseEntity
    {
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalValue { get; set; }

        public Guid CartId { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
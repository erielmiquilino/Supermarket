using System;

namespace Supermarket.Domain.Entities.Base
{
    public class BaseEntity
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime InsertDate { get; set; }
    }
}

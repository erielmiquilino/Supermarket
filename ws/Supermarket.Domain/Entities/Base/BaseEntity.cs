using System;

namespace Supermarket.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

		private DateTime? _insertDate;

		public DateTime? InsertDate
		{
			get => _insertDate;
            set => _insertDate = value ?? DateTime.UtcNow;
        }
	}
}

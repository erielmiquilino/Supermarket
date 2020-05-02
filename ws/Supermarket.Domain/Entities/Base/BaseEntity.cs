using System;

namespace Supermarket.Domain.Entities.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

		private DateTime? _insertDate;

		public DateTime? InsertDate
		{
			get { return _insertDate; }
			set { _insertDate = (value == null ? DateTime.UtcNow : value); }
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Domain.Models
{
    public class UserModel
    {
		private Guid _id;

		public Guid Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private String _name;

		public String Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private String _email;

		public String Email
		{
			get { return _email; }
			set { _email = value; }
		}

		private String _password;

		public String Password
		{
			get { return _password; }
			set { _password = value; }
		}

		private DateTime _insertDate;

		public DateTime InsertDate
		{
			get { return _insertDate; }
			set { _insertDate = value; }
		}


	}
}

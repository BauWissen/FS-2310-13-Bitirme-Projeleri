﻿using System;
namespace SalesUp.Entity
{
	public class ContactUs
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public bool IsCompleted { get; set; }
	}
}


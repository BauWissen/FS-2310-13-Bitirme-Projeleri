using System;
namespace SalesUp.Shared.ViewModels
{
	public class ContactUsViewModel
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsCompleted { get; set; }
    }
}


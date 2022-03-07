using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CONTACT_MANAGEMENT.Models
{
    public class ContactManagementModel
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } 
        public string submit { get; set; }
        public bool? IsFav { get; set; }
    }
}
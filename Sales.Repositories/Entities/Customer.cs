using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Repositories.Entities
{
    public partial class Customer
    {
        public long IdCustomer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Talacheria { get; set; }
        public DateTime CreationDate { get; set; }
        public bool? Status { get; set; }
    }
}

namespace Sales.Entitys.Request.DB
{
    using System;
    public class CustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string? Email { get; set; }
        public string? Talacheria { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? Status { get; set; }
    }
}

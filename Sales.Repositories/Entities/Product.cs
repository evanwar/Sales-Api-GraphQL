using System;
using System.Collections.Generic;

#nullable disable

namespace Sales.Repositories.Entities
{
    public partial class Product
    {
        public long IdProduct { get; set; }
        public string Name { get; set; }
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal WholesalePrice { get; set; }
        public long TotalUnits { get; set; }
        public DateTime? LastDelivery { get; set; }
        public bool? Status { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
    }
}

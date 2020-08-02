using System;
using System.Collections.Generic;

namespace Northwind.Api.Models
{
    public partial class Product
    {
        public Product()
        {
            Orderitem = new HashSet<Orderitem>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Orderitem> Orderitem { get; set; }
    }
}

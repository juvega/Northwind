using System;
using System.Collections.Generic;

namespace Northwind.Api.Models
{
    public partial class Order
    {
        public Order()
        {
            Orderitem = new HashSet<Orderitem>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal? TotalAmount { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Orderitem> Orderitem { get; set; }
    }
}

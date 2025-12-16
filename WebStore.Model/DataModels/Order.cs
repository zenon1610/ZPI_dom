using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.DataModels
{
    public class Order
    {
        public DateTime DeliveryDate { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }

        //Relacje 1:M z Address, Customer, Invoice
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = default!;
        public Invoice ? Invoice { get; set; }

        //Relacja M:N z produktami przez OrderProduct
        public IList<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
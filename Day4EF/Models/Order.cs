using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4EF.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public double Discount { get; set; } // Percent

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}

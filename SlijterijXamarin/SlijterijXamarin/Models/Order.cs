using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Slijterij.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public IEnumerable<OrderProduct> Products { get; set; }
    }
}

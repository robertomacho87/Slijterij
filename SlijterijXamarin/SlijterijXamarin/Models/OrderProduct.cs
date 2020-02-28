using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace Slijterij.Models
{
    public class OrderProduct
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }

        public int Amount { get; set; }
    }
}

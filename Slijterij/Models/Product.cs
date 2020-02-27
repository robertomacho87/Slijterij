using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Slijterij.Models
{
    public class Product
    {
        public int ID { get; set; }
        public int OriginID { get; set; }
        public int TypeID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public double AlcoholByVolume { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public int AmountInStock { get; set; }
        public bool Available { get; set; }

        public Origin Origin { get; set; }
        public TypeOfWhiskey Type { get; set; }
    }
}

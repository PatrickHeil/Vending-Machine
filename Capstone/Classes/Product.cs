using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string SlotId { get; set; }

<<<<<<< HEAD
        public string ProductName { get; set; }
=======
        public int Quantity { get; set; } = 0;
>>>>>>> 685dddbf992ab1ff9c6c22ec08211db4ef9a7d7e

        public decimal Price { get; set; }

        public string ProductType { get; set; }

        public int Quantity { get; } = 0;

        public virtual string Slogan { get; }

        public Product()
        {

        }

        public Product(string slotId, string productName, decimal price, string productType)
        {
            this.SlotId = slotId;
            this.ProductName = productName;
            this.Price = price;
            this.ProductType = productType;
        }
    }
}

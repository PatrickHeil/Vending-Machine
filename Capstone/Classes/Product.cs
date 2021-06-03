using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string SlotId { get; set; }

        public int Quantity { get; set; } = 0;

        public decimal Price { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

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

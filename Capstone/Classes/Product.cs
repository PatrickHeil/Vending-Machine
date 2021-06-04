using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Product
    {
        public string SlotId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public string ProductType { get; set; }

        public int Quantity { get; set; } = 5;

        public Product()
        {

        }

        public Product(string slotId, string productName, string price, string productType)
        {
            this.SlotId = slotId;
            this.ProductName = productName;
            this.Price = decimal.Parse(price);
            this.ProductType = productType;

        }
    }
}

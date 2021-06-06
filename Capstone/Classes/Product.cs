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
        public override bool Equals(Object obj)
        {
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            Product example = (Product)obj;
            return this.SlotId == example.SlotId;
            return this.ProductName == example.ProductName;
            return this.Price == example.Price;
            return this.ProductType == example.ProductType;
        }
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
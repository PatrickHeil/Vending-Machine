using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
namespace Capstone
{
    public class VendingMachine
    {
        public decimal Balance { get; } = 0;
        public Dictionary<Product, int> Inventory { get; set; }
        public VendingMachine()
        {
        }
        public VendingMachine(Dictionary<Product, int> inventory)
        {
            this.Inventory = inventory;
        }
    }
}
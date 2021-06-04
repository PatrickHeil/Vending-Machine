using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public decimal Balance { get; }

        public Dictionary<Product, int> Inventory { get; }

        public VendingMachine(Dictionary<Product, int> inventory, decimal balance)
        {
            this.Balance = balance;
            this.Inventory = new Dictionary<Product, int>();


        }

    }
}

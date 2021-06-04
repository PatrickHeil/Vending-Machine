using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public decimal Balance { get; } = 0;

        public Dictionary<Product, int> Inventory
        {
            get
            {
                string fullPath = "C:\\Users\\Student\\git\\dotnet-capstone-1-team-4\\vendingmachine.csv";
                //change to relative path?

                Dictionary<Product, int> inventory = new Dictionary<Product, int>();

                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] snackProperties = line.Split('|');

                        inventory.Add(new Product(snackProperties[0], snackProperties[1], snackProperties[2], snackProperties[3]), 5);
                    }
                    return inventory;
                }
            }
        }

        public VendingMachine(Dictionary<Product, int> inventory, decimal balance)
        {
            this.Balance = balance;
            this.Inventory = inventory;


        }


    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    public class Restocker
    {
        public int Quantity { get; set; } = 5;
        public Restocker()
        {
        }
        public Dictionary<Product, int> Inventory()
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
                    inventory.Add(new Product(snackProperties[0], snackProperties[1], snackProperties[2], snackProperties[3]), this.Quantity);
                }
                return inventory;
            }
        }
    }
}
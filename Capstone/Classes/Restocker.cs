using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    public class Restocker
    {
        public Restocker()
        {
        } 
        public Dictionary<Product, int> Inventory()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string relativeDirectory = @"..\..\..\..\vendingmachine.csv";
            string fullPath = Path.Combine(currentDirectory, relativeDirectory);            
            Dictionary<Product, int> inventory = new Dictionary<Product, int>();
            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return inventory;

        }
    }
}
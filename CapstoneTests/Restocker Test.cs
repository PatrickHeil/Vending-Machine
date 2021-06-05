using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using Capstone.Classes;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class RestockerTest
    {
        public static Dictionary<Product,int> TestDictionary()
        {
            Product a1 = new Product("A1", "Potato Crisps", "3.05", "Chip");
            Product a2 = new Product("A2", "Stackers", "1.45", "Chip");
            Product a3 = new Product("A3", "Grain Waves", "2.75", "Chip");
            Product a4 = new Product("A4", "Cloud Popcorn", "3.65", "Chip");
            Product b1 = new Product("B1", "Moonpie","1.80", "Candy");
            Product b2 = new Product("B2", "Cowtales", "1.50", "Candy");
            Product b3 = new Product("B3", "Wonka Bar", "1.50", "Candy");
            Product b4 = new Product("B4", "Crunchie", "1.75", "Candy");
            Product c1 = new Product("C1", "Cola", "1.25", "Drink");
            Product c2 = new Product("C2", "Dr. Salt", "1.50", "Drink");
            Product c3 = new Product("C3", "Mountain Melter", "1.50", "Drink");
            Product c4 = new Product("C4", "Heavy", "1.50", "Drink");
            Product d1 = new Product("D1", "U-Chews", "0.85", "Gum");
            Product d2 = new Product("D2", "Little League Chew", "0.95", "Gum");
            Product d3 = new Product("D3", "Chiclets", "0.75", "Gum");
            Product d4 = new Product("D4", "Triplemint", "0.75", "Gum");

            Dictionary<Product, int> expectedResult = new Dictionary<Product, int>();
            expectedResult[a1] = 5;
            expectedResult[a2] = 5;
            expectedResult[a3] = 5;
            expectedResult[a4] = 5;
            expectedResult[b1] = 5;
            expectedResult[b2] = 5;
            expectedResult[b3] = 5;
            expectedResult[b4] = 5;
            expectedResult[c1] = 5;
            expectedResult[c2] = 5;
            expectedResult[c3] = 5;
            expectedResult[c4] = 5;
            expectedResult[d1] = 5;
            expectedResult[d2] = 5;
            expectedResult[d3] = 5;
            expectedResult[d4] = 5;

            return expectedResult;
        }

        [TestMethod]
        public void RestockerCheck()
        {
            Restocker rs = new Restocker();

            Dictionary<Product, int> inventory = rs.Inventory();

            Dictionary<Product, int> expectedResult = TestDictionary();

            CollectionAssert.AreEqual(inventory, expectedResult);
        }
    }
}

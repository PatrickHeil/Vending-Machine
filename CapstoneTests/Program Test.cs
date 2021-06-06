using Capstone;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    class Program_Test
    {
        [TestMethod]
        public void MainTest()
        {
            Restocker restocker = new Restocker();
            Dictionary<Product, int> inventory = restocker.Inventory();


        }
    }
}

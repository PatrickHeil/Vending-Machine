﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            //string directory = "C:\\Users\\Student\\git\\dotnet - capstone - 1 - team - 4\\vendingmachine.csv";
            //string filename = "vendingmachine.csv";
            //string fullPath = Path.Combine(directory, filename);

            string fullPath = "C:\\Users\\Student\\git\\dotnet-capstone-1-team-4\\vendingmachine.csv";

<<<<<<< HEAD
            
            Product snackProduct = new Product();
            List<Product> productList = new List<Product>();

            try
            {
=======
            List<string> snackers = new List<string>();
            Product snackProduct = new Product();
                    
>>>>>>> 685dddbf992ab1ff9c6c22ec08211db4ef9a7d7e
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] snacks = line.Split('|');

<<<<<<< HEAD
                        snackProduct.SlotId = snacks[0];
                        snackProduct.ProductName = snacks[1];
                        string decimalConversion = snacks[2];
                        snackProduct.Price = decimal.Parse(decimalConversion);
                        snackProduct.ProductType = snacks[3];
                        productList.Add(snackProduct);
                    } 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            foreach(Product snack in productList)
            {
                Console.WriteLine(snack.ProductName);
            }
=======
                        for (int i = 0; i < snacks.Length; i++)
                        {
                        
                        //snackProduct.SlotId = snacks[i];
                        //snackProduct.ProductName = snacks[1];
                        //string decimalConversion = snacks[2];
                        //snackProduct.Price = decimal.Parse(decimalConversion);
                        //snackProduct.ProductType = snacks[3];
                        snackers.Add(snacks[i]);
                    }
>>>>>>> 685dddbf992ab1ff9c6c22ec08211db4ef9a7d7e




                    } 
                }
            foreach (string turd in snackers)
            {
                Console.WriteLine(turd);
            }

            Console.WriteLine("Hello World!");
            //Menu


            //1- Display Vending Machine Items
            //2- Purchase items
            //3- Exit



            //In 1 -Main
            // Display all items and how many are left.


            //In 2 -Main
            //1- Feed money - Whole dollar amounts and repeats  ... print to Log.txt
            //2- Select Product - same as display but with cost amount and code.... print to Log.txt
            //if they type wrong, .Clear, .writeline does not exist. return to menu
            //3-Finish Tranny- return change in smallest amount of COINS possible ...prints to Log.txt

            //Show balance on this screen and give change before going back to main menu

            //In 3 -Main
            //Exits the program

        }
    }
}

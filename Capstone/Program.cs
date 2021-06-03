using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        { //Dictionary<string, string> displayItems = new Dictionary<string, string>();
          //string directory = "C:\\Users\\Student\\git\\dotnet - capstone - 1 - team - 4\\vendingmachine.csv";
          //string filename = "vendingmachine.csv";
          //string fullPath = Path.Combine(directory, filename);
            int quantity = 5;
            //foreach (int itemSold in )
            //{
            //    quantity--;
            //}
            string fullPath = "C:\\Users\\Student\\git\\dotnet-capstone-1-team-4\\vendingmachine.csv";
            Product snackProduct = new Product();
            List<Product> productList = new List<Product>();
            List<string> snackers = new List<string>();
            List<string> slotId = new List<string>();
            List<string> productName = new List<string>();
            List<string> price = new List<string>();
            List<string> productType = new List<string>();

            using (StreamReader sr = new StreamReader(fullPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] snacks = line.Split('|');

                    for (int i = 0; i < snacks.Length; i++)
                    {

                        //snackProduct.SlotId = snacks[i];
                        //snackProduct.ProductName = snacks[1];
                        //string decimalConversion = snacks[2];
                        //snackProduct.Price = decimal.Parse(decimalConversion);
                        //snackProduct.ProductType = snacks[3];
                        snackers.Add(snacks[i]);
                    }
                }
                for (int i = 0; i < snackers.Count; i += 4)
                {
                    slotId.Add(snackers[i]);
                }
                for (int i = 1; i < snackers.Count; i += 4)
                {
                    productName.Add(snackers[i]);
                }
                for (int i = 2; i < snackers.Count; i += 4)
                {
                    price.Add(snackers[i]);
                }
                for (int i = 3; i < snackers.Count; i += 4)
                {
                    productType.Add(snackers[i]);
                }
            }


            //Menu

            decimal currentCash = 14.70M;

            //while ()
            //{
                Console.WriteLine("1: Display Vending Machine Items");
                Console.WriteLine("2: Purchase items");
                Console.WriteLine("3: Exit");
                string userSelection = Console.ReadLine();
                while (userSelection != "3")
                {
                    if (userSelection == "1")
                    {
                        Console.Clear();
                        for (int i = 0; i < productName.Count; i++)
                        {
                            Console.WriteLine($"{productName[i]}: {quantity} remaining");
                        }
                        Console.ReadLine();
                    }
                    else if (userSelection == "2")
                    {
                       // while ()
                        //{
                            Console.Clear();
                            Console.WriteLine("(1) Feed Money");
                            Console.WriteLine("(2) Select Product");
                            Console.WriteLine("(3) Finish Transaction");
                            Console.WriteLine("Your Current money provided is: $" + currentCash);
                            string userSelection2 = Console.ReadLine();
                            while (userSelection2 != "4")
                            {
                                if (userSelection2 == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please feed the machine money in whole dollar amounts and enter 0 when you are finished");

                                    string stringCurrentCash = Console.ReadLine();
                                    while (stringCurrentCash != "0")
                                    {
                                        currentCash += decimal.Parse(stringCurrentCash);
                                    }
                                    Console.WriteLine($"Your current balance is: ${currentCash}");
                                    Console.Read();
                                }
                                else if (userSelection2 == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please choose a product from the following options by typing the slot ID");
                                    for (int i = 0; i < productName.Count; i++)
                                    {
                                        Console.WriteLine($"{slotId[i]} {productName[i]} ${price[i]}: {quantity} remaining");
                                    }
                                    Console.ReadLine();

                                }
                                else if (userSelection2 == "3")
                                {
                                    Console.Clear();
                                    int quarters = 0;
                                    int dimes = 0;
                                    int nickels = 0;
                                    while (currentCash != 0)
                                    {
                                        if (currentCash >= .25M)
                                        {
                                            quarters = (int)(currentCash / .25M);
                                            currentCash -= quarters * .25M;
                                        }
                                        else if (currentCash > .10M && currentCash < .25M)
                                        {
                                            dimes = (int)(currentCash / .10M);
                                            currentCash -= dimes * .10M;
                                        }
                                        else if (currentCash > .05M && currentCash < .10M)
                                        {
                                            nickels = (int)(currentCash / .05M);
                                            currentCash -= nickels * .05M;
                                        }

                                    }
                                    Console.WriteLine($"Your change will be returned in {quarters} quarters, {dimes} dimes, and {nickels} nickles.");
                            Console.Read();
                                }
                            }
                       // }
                    }
                    else if (userSelection == "3")
                    {
                        Console.Clear();

                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again");
                    }
                }
            }




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
//}




using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {

            Restocker restocker = new Restocker();
            Dictionary<Product, int> inventory = restocker.Inventory();
            VendingMachine vendingMachine = new VendingMachine(inventory);
            LogKeeper log = new LogKeeper();




            //Menu

            decimal currentCash = 0M;

            // while ()
            // {
            bool main = true;
            bool main2 = true;
            while (main == true)
            {
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase items");
                Console.WriteLine("(3) Exit");
                string userSelection = Console.ReadLine();
                while (userSelection != "3")
                {

                    if (userSelection == "1")
                    {
                        Console.Clear();
                        foreach (KeyValuePair<Product, int> kvp in inventory)
                        {

                            Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} {kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");

                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else if (userSelection == "2")
                    {
                        main2 = true;
                        while (main2 == true)
                        {
                            Console.Clear();
                            Console.WriteLine("(1) Feed Money");
                            Console.WriteLine("(2) Select Product");
                            Console.WriteLine("(3) Finish Transaction");
                            Console.WriteLine("Your Current money provided is: $" + currentCash);
                            string userSelection2 = Console.ReadLine();
                            while (userSelection2 != "3")
                            {
                                if (userSelection2 == "1")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please feed the machine money in whole dollar amounts");

                                    string stringCurrentCash = Console.ReadLine();
                                    currentCash += decimal.Parse(stringCurrentCash);

                                    //write to Log.txt
                                    log.FeedWriter(stringCurrentCash, currentCash.ToString());

                                    Console.WriteLine($"Your current balance is: ${currentCash}");
                                    Console.ReadLine();
                                    break;
                                }
                                else if (userSelection2 == "2")
                                {
                                    Console.Clear();
                                    Console.WriteLine("Please choose a product from the following options by typing the slot ID");

                                    foreach (KeyValuePair<Product, int> kvp in inventory)
                                    {
                                        if(kvp.Value != 0)
                                        {
                                            Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} {kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");
                                        }
                                        else Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} {kvp.Key.Price} {kvp.Key.ProductType} quantity: SOLD OUT");
                                    }
                                    string slotIdPick = Console.ReadLine();


                                    try
                                    {
                                        foreach (KeyValuePair<Product, int> kvp in inventory)
                                        {

                                            if (slotIdPick == kvp.Key.SlotId)
                                            {

                                                if (kvp.Key.Price <= currentCash && kvp.Value > 0)
                                                {
                                                    //write to Log.txt
                                                    log.SaleWriter($"{kvp.Key.ProductName}", $"{kvp.Key.SlotId}", currentCash.ToString(), $"{currentCash - kvp.Key.Price}");

                                                    currentCash -= kvp.Key.Price;
                                                    int currentCount = 0;
                                                    inventory.TryGetValue(kvp.Key, out currentCount);
                                                    inventory[kvp.Key] = currentCount - 1;
                                                    if (slotIdPick.Contains("A"))
                                                    {
                                                        //CHIP
                                                        Console.WriteLine("Crunch Crunch, Yum!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (slotIdPick.Contains("B"))
                                                    {
                                                        //CANDY 
                                                        Console.WriteLine("Munch Munch, Yum!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (slotIdPick.Contains("C"))
                                                    {
                                                        //DRINK"Glug Glug, Yum!"
                                                        Console.WriteLine("Glug Glug, Yum!");
                                                        Console.ReadLine();
                                                    }
                                                    else if (slotIdPick.Contains("D"))
                                                    {
                                                        //GUM"Chew Chew, Yum!"
                                                        Console.WriteLine("Chew Chew, Yum!");
                                                        Console.ReadLine();
                                                    }


                                                }
                                                else if (kvp.Value == 0)
                                                {

                                                    Console.WriteLine("SOLD OUT");
                                                    break;
                                                }
                                                else if (kvp.Key.Price > currentCash)
                                                {
                                                    Console.WriteLine("Please enter more cash");
                                                }


                                            }
                                        }
                                    }

                                    catch (Exception ex)
                                    {

                                        // break;
                                    }
                                }

                                //Console.ReadLine();
                                break;
                            }
                            if (userSelection2 == "3")
                            {
                                Console.Clear();
                                int quarters = 0;
                                int dimes = 0;
                                int nickels = 0;
                                while (currentCash != 0)
                                {
                                    log.ChangeWriter(currentCash.ToString()); //writing to Log.txt
                                    
                                    if (currentCash >= .25M)
                                    {
                                        quarters = (int)(currentCash / .25M);
                                        currentCash -= quarters * .25M;
                                    }
                                    else if (currentCash >= .10M && currentCash < .25M)
                                    {
                                        dimes = (int)(currentCash / .10M);
                                        currentCash -= dimes * .10M;
                                    }
                                    else if (currentCash >= .05M && currentCash < .10M)
                                    {
                                        nickels = (int)(currentCash / .05M);
                                        currentCash -= nickels * .05M;
                                    }

                                }
                                Console.WriteLine($"Your change will be returned in {quarters} quarters, {dimes} dimes, and {nickels} nickles.");
                                Console.ReadLine();
                                main2 = false;
                                break;
                            }

                        }
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid entry, please try again");
                        break;
                    }
                }
                if (userSelection == "3")
                {
                    Console.Clear();
                    main = false;
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
    }
}




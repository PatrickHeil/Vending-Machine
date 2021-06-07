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
            LogKeeper log = new LogKeeper();
            //Menu
            decimal currentCash = 0M;
            bool main = true;
            bool main2 = true;
            while (main == true) //MAIN MENU
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase items");
                Console.WriteLine("(3) Exit");
                string userSelection = Console.ReadLine();
                while (userSelection != "3")
                {
                    if (userSelection == "1") //DISPLAY ITEMS
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                        Console.WriteLine();
                        foreach (KeyValuePair<Product, int> kvp in inventory)
                        {
                            if (kvp.Value != 0)
                            {
                                Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} ${kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");
                            }
                            else Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} ${kvp.Key.Price} {kvp.Key.ProductType} quantity: SOLD OUT");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any key to return to main menu.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                    else if (userSelection == "2") //PURCHASE ITEMS
                    {
                        main2 = true;
                        while (main2 == true)
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                            Console.WriteLine();
                            Console.WriteLine("(1) Feed Money");
                            Console.WriteLine("(2) Select Product");
                            Console.WriteLine("(3) Finish Transaction");
                            Console.WriteLine();
                            Console.WriteLine("Your Current balance is: $" + currentCash);
                            string userSelection2 = Console.ReadLine();
                            
                            while (userSelection2 != "3")
                            {
                                if (userSelection2 == "1") //FEED MONEY
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                                    Console.WriteLine();
                                    Console.WriteLine("Please feed the machine money in increments of 1, 2, 5, or 10");
                                    string stringCurrentCash = Console.ReadLine();
                                    if (stringCurrentCash == "1" || stringCurrentCash == "2" || stringCurrentCash == "5" || stringCurrentCash == "10")
                                    {
                                        currentCash += decimal.Parse(stringCurrentCash);
                                        log.FeedWriter(stringCurrentCash, currentCash.ToString()); //WRITE TO LOG
                                    }
                                    else
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Please insert correct bill: $1, $2, $5, or $10.");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine($"Your current balance is: ${currentCash}");
                                    Console.ReadLine();
                                    break;
                                }
                                else if (userSelection2 == "2") //SELECT PRODUCT
                                {
                                    Console.Clear();
                                    Console.WriteLine();
                                    Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                                    Console.WriteLine();
                                    Console.WriteLine("Please choose a product from the following options by typing the slot ID");
                                    Console.WriteLine($"Your current balance is: ${currentCash}");
                                    Console.WriteLine();
                                    foreach (KeyValuePair<Product, int> kvp in inventory)
                                    {
                                        if (kvp.Value != 0)
                                        {
                                            Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} ${kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");
                                        }
                                        else Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} ${kvp.Key.Price} {kvp.Key.ProductType} quantity: SOLD OUT");
                                    }
                                    string slotIdPick = Console.ReadLine();
                                    try
                                    {
                                        foreach (KeyValuePair<Product, int> kvp in inventory)
                                        {
                                            bool aSelect = (slotIdPick.ToUpper().Contains("A1") || slotIdPick.ToUpper().Contains("A2") || slotIdPick.ToUpper().Contains("A3") || slotIdPick.ToUpper().Contains("A4"));
                                            bool bSelect = (slotIdPick.ToUpper().Contains("B1") || slotIdPick.ToUpper().Contains("B2") || slotIdPick.ToUpper().Contains("B3") || slotIdPick.ToUpper().Contains("B4"));
                                            bool cSelect = (slotIdPick.ToUpper().Contains("C1") || slotIdPick.ToUpper().Contains("C2") || slotIdPick.ToUpper().Contains("C3") || slotIdPick.ToUpper().Contains("C4"));
                                            bool dSelect = (slotIdPick.ToUpper().Contains("D1") || slotIdPick.ToUpper().Contains("D2") || slotIdPick.ToUpper().Contains("D3") || slotIdPick.ToUpper().Contains("D4"));
                                            
                                            if (aSelect || bSelect || cSelect || dSelect)
                                            {
                                                if (slotIdPick.ToUpper() == kvp.Key.SlotId)
                                                {


                                                    if (kvp.Key.Price <= currentCash && kvp.Value > 0)
                                                    {   //WRITE TO LOG
                                                        log.SaleWriter($"{kvp.Key.ProductName}", $"{kvp.Key.SlotId}", currentCash.ToString(), $"{currentCash - kvp.Key.Price}");
                                                        currentCash -= kvp.Key.Price;
                                                        int currentCount = 0;
                                                        inventory.TryGetValue(kvp.Key, out currentCount);
                                                        inventory[kvp.Key] = currentCount - 1;

                                                        if (aSelect)
                                                        {
                                                            //CHIP
                                                            Console.WriteLine();
                                                            Console.WriteLine($"{kvp.Key.ProductName}: ${kvp.Key.Price}. Your balance remaining is {currentCash}");
                                                            Console.WriteLine();
                                                            Console.WriteLine("Crunch Crunch, Yum!");
                                                        }
                                                        else if (bSelect)
                                                        {
                                                            //CANDY
                                                            Console.WriteLine();
                                                            Console.WriteLine($"{kvp.Key.ProductName}: ${kvp.Key.Price}. Your balance remaining is {currentCash}");
                                                            Console.WriteLine();
                                                            Console.WriteLine("Munch Munch, Yum!");
                                                        }
                                                        else if (cSelect)
                                                        {
                                                            //DRINK
                                                            Console.WriteLine();
                                                            Console.WriteLine($"{kvp.Key.ProductName}: ${kvp.Key.Price}. Your balance remaining is {currentCash}");
                                                            Console.WriteLine();
                                                            Console.WriteLine("Glug Glug, Yum!");
                                                        }
                                                        else if (dSelect)
                                                        {
                                                            //GUM
                                                            Console.WriteLine();
                                                            Console.WriteLine($"{kvp.Key.ProductName}: ${kvp.Key.Price}. Your balance remaining is {currentCash}");
                                                            Console.WriteLine();
                                                            Console.WriteLine("Chew Chew, Yum!");
                                                        }
                                                        Console.ReadLine();
                                                    
                                                    }
                                                }
                                                else if (kvp.Value < 1)
                                                {
                                                    Console.WriteLine("SOLD OUT");
                                                    Console.ReadLine();
                                                    break;
                                                }
                                                else if (kvp.Key.Price > currentCash)
                                                {
                                                    Console.WriteLine("Please enter more cash");
                                                    Console.ReadLine();
                                                    break;
                                                }


                                            }
                                            if (!aSelect && !bSelect && !cSelect && !dSelect)
                                            {
                                                Console.WriteLine("Please enter a valid selection.");
                                                Console.ReadLine();
                                                break;
                                            }

                                        }
                                    }
                                    catch (Exception) //JUST IN CASE:
                                    {
                                        Console.WriteLine("Returning you to Purchase Menu.");
                                        break;
                                    }
                                }
                                break;
                            }
                            if (userSelection2 == "3")//FINALIZE TRANSACTION
                            {
                                Console.Clear();
                                int quarters = 0;
                                int dimes = 0;
                                int nickels = 0;
                                decimal previousCash = currentCash;
                                while (currentCash != 0)
                                {
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
                                log.ChangeWriter(previousCash.ToString(), currentCash.ToString()); //WRITE TO LOG
                                Console.WriteLine();
                                Console.WriteLine("+++ Umbrella Corp +++ VEND-O-MATIC 800 +++");
                                Console.WriteLine();
                                Console.WriteLine($"Your change will be returned in {quarters} quarters, {dimes} dimes, and {nickels} nickles."); //RETURN CHANGE
                                Console.ReadLine();
                                main2 = false;
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid entry, please try again.");
                        Console.ReadLine();
                        break;
                    }
                }
                if (userSelection == "3") //EXIT
                {
                    Console.Clear();
                    main = false;
                }
            }
        }
    }
}



























//using Capstone.Classes;
//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace Capstone
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            Restocker restocker = new Restocker();
//            Dictionary<Product, int> inventory = restocker.Inventory();
//            //VendingMachine vendingMachine = new VendingMachine(inventory);
//            LogKeeper log = new LogKeeper();


//            decimal currentCash = 0M;
//            bool main = true;
//            bool main2 = true;
//            while (main == true)
//            {
//                MainMenu();
//                string userSelection = Console.ReadLine();
//                while (userSelection != "3")
//                {

//                    if (userSelection == "1")
//                    {
//                        ListOfProducts();
//                        break;
//                    }
//                    else if (userSelection == "2")
//                    {
//                        main2 = true;
//                        while (main2 == true)
//                        {
//                            MainMenu2();
//                            Console.WriteLine("Your Current money provided is: $" + currentCash);
//                            string userSelection2 = Console.ReadLine();
//                            while (userSelection2 != "3")
//                            {
//                                if (userSelection2 == "1")
//                                {
//                                    Console.Clear();
//                                    currentCash = FeedMoney(currentCash);
//                                    break;
//                                }
//                                else if (userSelection2 == "2")
//                                {
//                                    Console.Clear();
//                                    foreach (KeyValuePair<Product, int> k in inventory)
//                                    {

//                                        if (k.Value != 0)
//                                        {
//                                            Console.WriteLine($"{k.Key.SlotId} {k.Key.ProductName} {k.Key.Price} {k.Key.ProductType} quantity: {k.Value}");
//                                        }
//                                        else Console.WriteLine($"{k.Key.SlotId} {k.Key.ProductName} {k.Key.Price} {k.Key.ProductType} quantity: SOLD OUT");

//                                    }
//                                    currentCash = BuyProduct(currentCash);
//                                    break;
//                                }
//                            }
//                            if (userSelection2 == "3")
//                            {
//                                Console.Clear();
//                                currentCash = GiveChange(currentCash);
//                                main2 = false;
//                                break;
//                            }
//                        }
//                        break;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Invalid entry, please try again");
//                        break;
//                    }
//                }
//                if (userSelection == "3")
//                {
//                    Console.Clear();
//                    main = false;
//                }
//            }
//        }
//        public static void MainMenu()
//        {
//            Console.WriteLine("(1) Display Vending Machine Items");
//            Console.WriteLine("(2) Purchase items");
//            Console.WriteLine("(3) Exit\n");

//        }
//        public static void ListOfProducts()
//        {
//            Console.Clear();
//            Restocker restocker = new Restocker();
//            Dictionary<Product, int> inventory = restocker.Inventory();
//            foreach (KeyValuePair<Product, int> kvp in inventory)
//            {

//                Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} {kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");

//            }
//            Console.WriteLine();
//            Console.WriteLine("Press any key to return to the menu.");
//            Console.ReadLine();
//            Console.Clear();
//        }
//        public static void MainMenu2()
//        {
//            Console.Clear();

//            Console.WriteLine("(1) Feed Money");
//            Console.WriteLine("(2) Select Product");
//            Console.WriteLine("(3) Finish Transaction");
//        }
//        public static decimal FeedMoney(decimal currentCash)
//        {
//            LogKeeper log = new LogKeeper();
//            Console.WriteLine("Please feed the machine money in increments of 1, 2, 5, or 10");
//            string stringCurrentCash = Console.ReadLine();
//            if (stringCurrentCash == "1" || stringCurrentCash == "2" || stringCurrentCash == "5" || stringCurrentCash == "10")
//            {

//                currentCash += decimal.Parse(stringCurrentCash);
//            }
//            else
//            {
//                Console.WriteLine("Invalid bill");
//            }
//            //write to Log.txt
//            log.FeedWriter(stringCurrentCash, currentCash.ToString());
//            Console.WriteLine($"Your current balance is: ${currentCash}");
//            Console.ReadLine();
//            return currentCash;
//        }
//        public static decimal BuyProduct(decimal currentCash)
//        {
//            try
//            {
//                Restocker restocker = new Restocker();
//                Dictionary<Product, int> inventory = restocker.Inventory();
//                LogKeeper log = new LogKeeper();
//                Console.WriteLine("Please choose a product from the following options by typing the slot ID");
//                string slotIdPick = Console.ReadLine();
//                foreach (KeyValuePair<Product, int> kvp in inventory)
//                {
//                    if (slotIdPick.ToUpper() == kvp.Key.SlotId)
//                    {

//                        if (kvp.Key.Price <= currentCash && kvp.Value > 0)
//                        {

//                            //write to Log.txt
//                            log.SaleWriter($"{kvp.Key.ProductName}", $"{kvp.Key.SlotId}", currentCash.ToString(), $"{currentCash - kvp.Key.Price}");
//                            QuantityReducer(kvp.Value);
//                            int currentCount = 0;

//                            inventory.TryGetValue(kvp.Key, out currentCount);
//                            inventory[kvp.Key] = currentCount - 1;
//                            if (slotIdPick.ToUpper().Contains("A"))
//                            {
//                                Console.Clear();
//                                Console.WriteLine("Crunch Crunch, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }
//                            else if (slotIdPick.ToUpper().Contains("B"))
//                            {
//                                Console.Clear();
//                                Console.WriteLine("Munch Munch, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }
//                            else if (slotIdPick.ToUpper().Contains("C"))
//                            {
//                                Console.Clear();
//                                Console.WriteLine("Glug Glug, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }
//                            else if (slotIdPick.ToUpper().Contains("D"))
//                            {
//                                Console.Clear();
//                                Console.WriteLine("Chew Chew, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }


//                        }
//                        else if (kvp.Value == 0)
//                        {

//                            Console.WriteLine("SOLD OUT");
//                            break;
//                        }
//                        else if (kvp.Key.Price > currentCash)
//                        {
//                            Console.Clear();
//                            Console.WriteLine("Please enter more cash");
//                            Console.ReadLine();
//                            break;
//                        }
//                        //return values;

//                    }
//                }

//            }
//            catch(Exception ex)
//            {

//            }
//            return currentCash;
//        }
//        public static decimal GiveChange(decimal currentCash)
//        {
//            int quarters = 0;
//            int dimes = 0;
//            int nickels = 0;
//            LogKeeper log = new LogKeeper();
//            while (currentCash != 0)
//            {
//                log.ChangeWriter(currentCash.ToString()); //writing to Log.txt

//                if (currentCash >= .25M)
//                {
//                    quarters = (int)(currentCash / .25M);
//                    currentCash -= quarters * .25M;
//                }
//                else if (currentCash >= .10M && currentCash < .25M)
//                {
//                    dimes = (int)(currentCash / .10M);
//                    currentCash -= dimes * .10M;
//                }
//                else if (currentCash >= .05M && currentCash < .10M)
//                {
//                    nickels = (int)(currentCash / .05M);
//                    currentCash -= nickels * .05M;
//                }

//            }
//            Console.WriteLine($"Your change will be returned in {quarters} quarters, {dimes} dimes, and {nickels} nickles.");
//            Console.ReadLine();
//            return currentCash;
//        }
//        //public static int Quantity()
//        //{                Restocker restocker = new Restocker();
//        //        Dictionary<Product, int> inventory = restocker.Inventory();
//        //    int newQuantity = 0;
//        //    foreach (KeyValuePair<Product,int> kvp in inventory)
//        //    {
//        //        return newQuantity = kvp.Value;
//        //    }
//        //    return 0;
//        //}
//        public static Dictionary<Product,int> QuantityReducer(int qty)
//        {
//            Restocker restocker = new Restocker();
//            Dictionary<Product, int> inventory = restocker.Inventory();
//            int qtyHolder = 0;
//            try
//            {


//                foreach (KeyValuePair<Product, int> kvp in inventory)
//                {
//                    qtyHolder = kvp.Value;
//                    qtyHolder--;
//                    inventory[kvp.Key] = qtyHolder;
//                }
//                return inventory;
//            }
//            catch (Exception ex)
//            {

//            }
//            return inventory;
//        }
//    }
//}




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
            //VendingMachine vendingMachine = new VendingMachine(inventory);
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
                                        Console.WriteLine($"{kvp.Key.SlotId} {kvp.Key.ProductName} {kvp.Key.Price} {kvp.Key.ProductType} quantity: {kvp.Value}");
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
                                            else
                                            {
                                                Console.WriteLine("Invalid entry, please try again");
                                                break;
                                            }
                                        }
                                    }

                                    catch (Exception ex)
                                    {

                                        // break;
                                    }
                                }

                                Console.ReadLine();
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
//            //Console.WriteLine("|############################################|");
//            //Console.WriteLine("|#|                           |##|````````|##|");
//            //Console.WriteLine("|#|  =====  ..--''`  |~~``|   |##|Umbrella|##|");
//            //Console.WriteLine(@"|#|  |   |  \     |  :    |   |##|  Corp  |##|");
//            //Console.WriteLine("|#|  |___|   /___ |  | ___|   |##| Vendo- |##|");
//            //Console.WriteLine(@"|#|  /=__\  ./.__\   |/,__\   |##| Matic  |##|");
//            //Console.WriteLine(@"|#|  \__//   \__//    \__//   |##|__800___|##|");
//            //Console.WriteLine("|#|===========================|##############|");
//            //Console.WriteLine("|#|```````````````````````````|##############|");
//            //Console.WriteLine("|#| =.._      +++     //////  |##############|");
//            //Console.WriteLine(@"|#| \/  \     | |     \    \  |#|`````````|##|");
//            //Console.WriteLine(@"|#|  \___\    |_|     /___ /  |#| _______ |##|");
//            //Console.WriteLine(@"|#|  / __\\  /|_|\   // __\   |#| |1|2|3| |##|");
//            //Console.WriteLine(@"|#|  \__//-  \|_//   -\__//   |#| |4|5|6| |##|");
//            //Console.WriteLine("|#|===========================|#| |7|8|9| |##|");
//            //Console.WriteLine("|#|```````````````````````````|#| ``````` |##|");
//            //Console.WriteLine("|#| ..--    ______   .--._.   |#|[=======]|##|");
//            //Console.WriteLine(@"|#| \   \   |    |   |    |   |#|  _   _  |##|");
//            //Console.WriteLine(@"|#|  \___\  : ___:   | ___|   |#| ||| ( ) |##|");
//            //Console.WriteLine(@"|#|  / __\  |/ __\   // __\   |#| |||  `  |##|");
//            //Console.WriteLine(@"|#|  \__//   \__//  /_\__//   |#|  ~      |##|");
//            //Console.WriteLine("|#|===========================|#|_________|##|");
//            //Console.WriteLine("|#|```````````````````````````|##############|");
//            //Console.WriteLine("|############################################|");
//            //Console.WriteLine("|#|||||||||||||||||||||||||||||####```````###|");
//            //Console.WriteLine(@"|#||||||||||||PUSH|||||||||||||####\|||||/###|");
//            //Console.WriteLine("|############################################|");
//            //Console.WriteLine(@"\\\\\\\\\\\\\\\\\\\\\\///////////////////////");
//            //Console.WriteLine(" |________________________________|UCVM|_____|");

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

//                                //Console.WriteLine(@"    ___ ___  ___ ___  ___.-------------- -.");
//                                //Console.WriteLine(@" .'\__\'\__\'\__\'\__\'\__,`   .  ____ ___ \");
//                                //Console.WriteLine(@" |\/ __\/ __\/ __\/ __\/ _:\   |`.  \  \___ \");
//                                //Console.WriteLine(@" \\'\__\'\__\'\__\'\__\'\_`.__|''`. \  \___ \");
//                                //Console.WriteLine(@" \\/ __\/ __\/ __\/ __\/ __:                \");
//                                //Console.WriteLine(@" \\'\__\'\__\'\__\ \__\'\_;-----------------`");
//                                //Console.WriteLine(@" \\/   \/   \/   \/   \/  :                 |");
//                                //Console.WriteLine(@" \| ______________________; ________________|");
//                                //Console.WriteLine();
//                                Console.WriteLine("Munch Munch, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }
//                            else if (slotIdPick.ToUpper().Contains("C"))
//                            {
//                                Console.Clear();
//                                //Console.WriteLine(@"           .e$.                           z$$e.d$$$.      z$b   z");
//                                //Console.WriteLine(@"          d$' .d                       .$$''d'F ^ *$$$e  z$' $ .$'");
//                                //Console.WriteLine(@"        e$P    $%                    d$P .'  F    '$$'d$  .e$'");
//                                //Console.WriteLine(@"       $$F                         .$$'  F  J       '$$z$$$'");
//                                //Console.WriteLine(@"     .$$'     .$'3 .$''  .$P $$  $$ 4$$ $  4'     $$  .");
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();     
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                //Console.WriteLine();
//                                Console.WriteLine("Glug Glug, Yum!");
//                                Console.ReadLine();
//                                break;
//                            }
//                            else if (slotIdPick.ToUpper().Contains("D"))
//                            {
//                                Console.Clear();
//                                //Console.WriteLine(@"                      ____");
//                                //Console.WriteLine(@"          ___       .' /:::.      ___");
//                                //Console.WriteLine(@"          \  ' -.  / (:::-' \  .-'  /");
//                                //Console.WriteLine(@"           >_-=.\/:\__\/__   \/.=-_<");
//                                //Console.WriteLine(@"           > -= '/\::::/\:::\/\'=- <");
//                                //Console.WriteLine(@"          / __.-'  \: :' )::/  '-.__\");
//                                //Console.WriteLine(@"                    '.__/::'");
//                                Console.WriteLine();
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




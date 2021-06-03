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

            List<string> productProperties = new List<string>();
            
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        //string[] snacks = line.Split('|');

                        // Add each value to product properties array
                        
                        productProperties.Add(line);

                    } //go to the next line until the end is reached
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }

             Console.WriteLine(productProperties);


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

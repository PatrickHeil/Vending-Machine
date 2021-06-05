using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class LogKeeper
    {
        public LogKeeper()
        {

        }

        public void SaleWriter(string productName, string slotId, string currentBalance, string balanceAfterPurchase)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.Now.ToString();
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{dateTime} {productName} {slotId} ${currentBalance} ${balanceAfterPurchase}");
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FeedWriter(string moneyInserted, string currentBalance)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.Now.ToString();
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{dateTime} FEED MONEY: ${moneyInserted} ${currentBalance}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeWriter(string moneyRemaining, string balanceOfZero)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.Now.ToString();
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{dateTime} GIVE CHANGE: ${moneyRemaining} ${balanceOfZero}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

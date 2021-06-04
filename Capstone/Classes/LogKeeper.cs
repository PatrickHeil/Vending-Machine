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

        public DateTime DateTime { get; }

        public void SaleWriter(string productName, string slotId, decimal currentBalance, decimal balanceAfterPurchase)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.ToString();
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

        public void FeedWriter(decimal moneyInserted, decimal currentBalance)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.ToString();
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

        public void ChangeWriter(decimal moneyRemaining)
        {
            string fileName = "Log.txt";
            string dateTime = DateTime.ToString();
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true))
                {
                    sw.WriteLine($"{dateTime} GIVE CHANGE: ${moneyRemaining} $0.00");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

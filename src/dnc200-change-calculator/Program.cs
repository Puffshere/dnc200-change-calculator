using System;
using System.Linq;

namespace dnc200_change_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            decimal cost = 0;
            decimal moneyGiven = 0;
            Console.WriteLine("The price of the item is:  ");
            string price = Console.ReadLine();
            bool isCorrect = decimal.TryParse(price, out cost);
            if (isCorrect)
            {
                Console.WriteLine(cost);
            }
            Console.WriteLine("Amount recieved for purchase of item:  ");
            string amount = Console.ReadLine();
            isCorrect = decimal.TryParse(amount, out moneyGiven);
            if (isCorrect)
            {
                Console.WriteLine(moneyGiven);
            }

            Console.ReadKey();
        }
    }
}

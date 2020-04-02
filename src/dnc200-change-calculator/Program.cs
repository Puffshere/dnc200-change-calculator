using System;
using System.Linq;
using System.Collections.Generic;

namespace dnc200_change_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string price = "";
            decimal cost = 0;
            decimal moneyGiven = 0;
            bool repeat = true;

            while (repeat)
            {
                Console.Write("The price of the item is:  $" + price);
                price = Console.ReadLine();
                bool isCorrect = decimal.TryParse(price, out cost);
                if (isCorrect)
                {
                    Console.WriteLine("Price of the item accepted.");
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount.");
                    repeat = true;
                }
            }
            while (!repeat)
            {
                Console.Write("Amount recieved for purchase of item:  $");
                string amount = Console.ReadLine();
                bool isCorrect = decimal.TryParse(amount, out moneyGiven);
                if (isCorrect)
                {
                    Console.WriteLine("Amount given for puchase of the item is accepted.");
                    repeat = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid amount.");
                    repeat = false;
                }
            }
            string answer = Program.GetChange(cost, moneyGiven);
            Console.WriteLine(answer);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit program . . .");
            Console.Read();
        }


        static public string GetChange(decimal cost, decimal moneyGiven)
        {
            decimal changeDue = moneyGiven - cost;
            decimal x = moneyGiven - cost;
            var final = new List<decimal>();
            var finalStrings = new List<string>();

            if (changeDue > 0)
            {
                string message = "You are still owed $" + x + ".";
                finalStrings.Add(message);
                changeDue = Math.Abs(changeDue);

                decimal[] amounts = { 1m, 0.25m, 0.10m, 0.05m, 0.01m };

                for (int i = 0; i < amounts.Length; i++)
                {
                    decimal amount = Math.Floor(changeDue / amounts[i]);
                    decimal remainder = (changeDue % amounts[i]);
                    final.Add(amount);
                    changeDue = remainder;
                }
            }
            if (x == 0)
            {
                string message = "No change is due.     ";
                finalStrings.Add(message);
            }


            bool yes = true;
            if (x < 0)
            {
                yes = false;
                changeDue = Math.Abs(changeDue);
                Console.WriteLine("You still owe $" + changeDue + ".      ");
                decimal[] amounts = { 1m, 0.25m, 0.10m, 0.05m, 0.01m };
                for (int i = 0; i < amounts.Length; i++)
                {
                    decimal amount = Math.Floor(changeDue / amounts[i]);
                    decimal remainder = (changeDue % amounts[i]);
                    final.Add(amount);
                    changeDue = remainder;
                }
            }

            decimal[] results = final.ToArray();
            string answer = "";
            if (yes)
            {
                if (results.Length > 1)
                {
                    string[] units = { "dollars", "quarters", "dimes", "nickels", "pennies" };
                    string[] unitsSingular = { "dollar", "quarter", "dime", "nickel", "penny" };
                    Console.WriteLine();

                    string preface = "The total change due is:  \r\n";
                    finalStrings.Add(preface);
                    for (int i = 0; i < results.Length; i++)
                        if (results[i] == 1)
                        {
                            string change = $"{results[i]} {unitsSingular[i]},\r\n";
                            finalStrings.Add(change);
                        }
                        else
                        {
                            string change = $"{results[i]} {units[i]},\r\n";
                            finalStrings.Add(change);
                        }
                }
            }
            else
            {
                answer = "You can not afford this item come back when you have more money.  Goodbye!    ";
                finalStrings.Add(answer);
            }
            string[] resultArray = finalStrings.ToArray();
            answer = string.Join(" ", resultArray);


            answer = answer.Remove(answer.Length - 3);



            return answer;
        }
    }
}

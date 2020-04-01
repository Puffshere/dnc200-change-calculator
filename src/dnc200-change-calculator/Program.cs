﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace dnc200_change_calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string price = "";
            string amount = "";
            decimal cost = 0;
            decimal moneyGiven = 0;
            bool repeat = true;
            bool isCorrect = false;
            //bool enough = true;

            while (repeat)
            {
                Console.Write("The price of the item is:  $" + price);
                price = Console.ReadLine();
                isCorrect = decimal.TryParse(price, out cost);
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
                amount = Console.ReadLine();
                isCorrect = decimal.TryParse(amount, out moneyGiven);
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


                if (moneyGiven < cost)
                {
                    Console.WriteLine("You do not have enough mone to puchase item.  Add more money.");
                    repeat = false;
                }

                if (moneyGiven >= cost)
                {
                    repeat = true;
                    //enough = true;
                }
            }

            Console.WriteLine("Press any key to exit program . . .");
            Console.Read();
        }
    }
}

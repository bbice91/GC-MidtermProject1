using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POS_MidtermTerm_Project1
{
    internal class CashRegister
    {        
        public static double GetPaidInCash(double grandTotal)
        {
            Console.WriteLine("Enter the Cash tendered");
            double cashIn;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out cashIn))
                {
                    while (cashIn - grandTotal < 0)
                    {
                        Console.WriteLine($"${cashIn} - This isn't enough money, your total is ${grandTotal}.");
                        Console.WriteLine($"Please give us at least {grandTotal}.");

                        if (double.TryParse(Console.ReadLine(), out cashIn) && cashIn >= grandTotal)
                        {
                            double cashOut = cashIn - grandTotal;
                            return Math.Round(cashOut, 2);
                        }
                        else
                        {
                            continue;
                        }
                    }                
                }
                else
                {                    
                    Console.WriteLine("Enter the numerical value of the cash you want to give us");
                }
            }
        }
        public static void GetPaidByCheck(double grandTotal)
        {
            Console.WriteLine("Please provide your three digit check number");
            Regex checkNumberPattern = new Regex(@"^\b([0-9][0-9][1-9])\b");
            while (!checkNumberPattern.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("Your check number is wrong. Please try again");
            }
        }
        public static void GetPaidWithCreditCard(double grandTotal)
        {
            Console.WriteLine("Please input your card number.");
            Regex creditCardNumberPattern = new Regex(@"^\b\d{16}\b");
            while (!creditCardNumberPattern.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("This is a bad credit card number, please provide us with the correct credit card number.");
            }

            Console.WriteLine("What is the expiration date of your card? Format must be mm/yy.");
            Regex creditCardExpDatePattern = new Regex(@"^\b\d{2}/\d{2}\b");
            while (!creditCardExpDatePattern.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("You did not input the expiration date. The format is mm/yy.");
            }

            Console.WriteLine("Please enter the three digit CW code on the back of your card.");
            Regex creditCardCWPattern = new Regex(@"^\b\d{3}\b");
            while (!creditCardCWPattern.IsMatch(Console.ReadLine()))
            {
                Console.WriteLine("You did not input the proper CW code on the back of your card.");
            }
            Console.WriteLine("Thank you paying us exactly what you owe.");
        }
    }
}

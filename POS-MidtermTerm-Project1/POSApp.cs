using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MidtermTerm_Project1
{
    internal class POSApp
    {
        public static void Run()
        {            
            ConsoleFluff.MakePrettyConsole();
             try
             {
                    string userName = Menu.Welcome("Hello! Welcome to the Burger Hut II: Where our Menu starts at 10!\n", "Please enter the name for your Order: ");
                    bool anotherOrder = true;
                    while (anotherOrder)
                    {   
                        List<CartItem> cart = new List<CartItem>();
                        var userCart = Menu.SelectItemsForCart(Menu.ShowMenu("Here is our amazing list of delicious items!"), "Please enter the number corresponding to your food item!");
                        Menu.ShowReceipt(userCart);
                        string paymentType = Menu.AskForPayment("How would you like to pay for your awesome items?");
                        GetPaymentType.PaymentType(userCart, paymentType);
                        Menu.ShowReceipt(userCart, paymentType);
                        anotherOrder = TryValidate.GetValidation("Would you like to place another order? (y/n)");
                    }
                    Console.WriteLine("Thank you for ordering with us, have a wonderful day!");
                    } 
                    catch (Exception ex)
                    {
                        Console.WriteLine("How did you break our amazing Burger Hut II Point of Sale System? Please contact tech support at our earliest convience.\n");
                        Console.WriteLine($"Here is the esception you got {ex} and we have to deal with...\n");
             }
        }
    }
}

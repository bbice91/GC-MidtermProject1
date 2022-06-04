using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MidtermTerm_Project1
{
    public class Menu
    {
        public static string Welcome(string message, string otherMessage)
        {
            Console.WriteLine(message);
            Console.Write(otherMessage);
            string userName = Console.ReadLine();
            Console.WriteLine($"\nWelcome {userName}!\n");
            return userName;
        }
        public static List<Product> ShowMenu(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("");
            List<Product> products = Warehouse.getInventory();
            foreach (var product in products)
            {
                Console.WriteLine($" [{product.ProductID}] {product.Name} {product.Description} {product.Category} ${product.Price}");
            }
            Console.WriteLine("");
            return products;
        }
        public static List<CartItem> SelectItemsForCart(List<Product> products, string message)
        {
            var cart = new List<CartItem>();
            var addMoreItems = "y";
            while (addMoreItems == "y")
            {
                Console.WriteLine(message);
                var cartItem = new CartItem();
                int number = int.Parse(Console.ReadLine());                     
                while (!products.Any(x => x.ProductID == number))
                {
                    Console.WriteLine("That product does not exist in our amazing inventory");
                    number = int.Parse(Console.ReadLine());
                }

                cartItem.Product = CartAction.GetProductByProductId(number);
                Console.WriteLine($"How many {cartItem.Product.Name.Trim()}s would you like?");               
                while (true)
                {
                    double selectedNumber; 
                    if  (!double.TryParse(Console.ReadLine(), out  selectedNumber))
                    {
                    Console.WriteLine("This is a numerical input only, please enter the corrisponding two digit number for your item.");   
                    }
                    else
                    { 
                        cartItem.Quantity = selectedNumber;
                        break;
                    }
                }
                cart.Add(cartItem);
                Console.WriteLine("Would you like to order more items? (y/n)");
                addMoreItems = Console.ReadLine();
                Console.WriteLine("");
            }
            return cart;
        }
        public static void ShowReceipt(List<CartItem> userCart, string paymentType)
        {
            Console.WriteLine("You Ordered:\n");
            foreach (var item in userCart)
            {
                Console.WriteLine($"{item.Product.Name} ${item.Product.Price} x {item.Quantity}\n");
            }
            Console.WriteLine($"Your Subtotal is ${Calc.GetSubTotal(userCart)}");
            Console.WriteLine($"Tax is ${Calc.GetTax(userCart)}");
            Console.WriteLine($"Your Grand Total is ${Calc.GetGrandTotal(userCart)}\n");
            Console.WriteLine($"You Paid with {paymentType.ToUpper()}\n");
            Console.Beep();
        }
        public static void ShowReceipt(List<CartItem> userCart)
        {
            Console.WriteLine("You Ordered:\n");
            foreach (var item in userCart)
            {
                Console.WriteLine($"{item.Product.Name} ${item.Product.Price} x {item.Quantity}\n");
            }
            Console.WriteLine($"Your Subtotal is ${Calc.GetSubTotal(userCart)}");
            Console.WriteLine($"Tax is ${Calc.GetTax(userCart)}");
            Console.WriteLine($"Your Grand Total is ${Calc.GetGrandTotal(userCart)}\n");
        }
        public static string AskForPayment(string howToPay)
        {
            string userPaymentMethod;
            Console.WriteLine($"{howToPay} Cash, Check, or Credit Card?");
            userPaymentMethod = Console.ReadLine().Trim().ToLower();
            while (userPaymentMethod != "cash" && userPaymentMethod != "check" && userPaymentMethod != "credit card")
                {
                Console.Write("This is not a valid form of payment. Please try again: ");
                userPaymentMethod = Console.ReadLine().ToLower().Trim();
                }
            return userPaymentMethod;                
        }
    }
}

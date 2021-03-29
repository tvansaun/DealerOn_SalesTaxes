using System;
using System.Globalization;

namespace DealerOn_SalesTaxes
{
    /*****************************************
     * This program allows the user to fill a cart with items, then upon checkout calculates the
     * sales tax and displays a receipt. There are two main objects, "Items" and the "Cart". The 
     * Item refers to an individual item and its attributes (name, quantity, price, if it is
     * imported, and if it is tax exempt). The Cart holds a list of all items, and upon Checkout
     * calculates the total price and sales tax of all items then finally displays a receipt.
     * 
     * Test cases can be viewed in Test.cs and can be ran by uncommenting the lines in MainFunction.
     * ***************************************/
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Welcome to My Store");

            /***TESTS********************************
            Test t = new Test();
            //t.Test1();
            //t.Test2();
            //t.Test3();
            *****************************************/

            //Create new cart
            Cart cart = new Cart();

            //Begin shopping
            Shop(cart);

            //When done shopping, checkout
            cart.Checkout();

            Console.WriteLine("Thanks for shopping!");
        }


        static void Shop(Cart cart)
        {
            //Get action from user
            Console.WriteLine("Type 'A' to add an item to your cart or 'C' to checkout");
            string action = Console.ReadLine();

            //While the action is not checking out, take input for new item
            while(!action.Equals("C") && !action.Equals("c"))
            {
                string name = getName();
                int quantity = getQuantity();
                double price = getPrice();
                bool imported = isImported();
                bool exempt = isTaxExempt();

                Item item = new Item(name, quantity, price, imported, exempt);
                cart.AddItem(item);

                Console.WriteLine("Type 'A' to add another item to your cart or 'C' to checkout");
                action = Console.ReadLine();
            }
        }

        static string getName()
        {
            Console.Write("Item name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int getQuantity()
        {
            Console.Write("Quantity: ");
            string input = Console.ReadLine();

            if(!int.TryParse(input, out int quantity))
            {
                Console.WriteLine("Please enter a whole number");
                getQuantity();
            }

            return quantity;
        }


        static double getPrice()
        {
            Console.Write("Price: ");
            string input = Console.ReadLine();

            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            if (!double.TryParse(input, style, culture, out double price))
            {
                Console.WriteLine("Please enter a number");
                getPrice();
            }

            return price;
        }

        static bool isImported()
        {
            Console.Write("Is this item imported? (Type 'Y' for yes or 'N' for no): ");
            string input = Console.ReadLine();

            if (input.Equals("Y") || input.Equals("y"))
            {
                return true;
            }
                
            return false;
        }

        static bool isTaxExempt()
        {
            Console.Write("Is this a book, medical product, or food item? (Type 'Y' for yes or 'N' for no): ");
            string input = Console.ReadLine();

            if (input.Equals("Y") || input.Equals("y"))
            {
                return true;
            }

            return false;
        }
    }

}

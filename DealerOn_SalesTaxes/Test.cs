using System;
namespace DealerOn_SalesTaxes
{
    public class Test
    {

        public void Test1()
        {
            Cart cart = new Cart();

            Item item1 = new Item("Book", 2, 12.49, false, true);
            cart.AddItem(item1);

            Item item2 = new Item("Music CD", 1, 14.99, false, false);
            cart.AddItem(item2);

            Item item3 = new Item("Chocolate Bar", 1, 0.85, false, true);
            cart.AddItem(item3);

            cart.Checkout();
        }

        public void Test2()
        {
            Cart cart = new Cart();

            Item item1 = new Item("Imported box of chocolates", 1, 10.00, true, true);
            cart.AddItem(item1);

            Item item2 = new Item("Imported bottle of perfume", 1, 47.50, true, false);
            cart.AddItem(item2);

            cart.Checkout();
        }

        public void Test3()
        {
            Cart cart = new Cart();

            Item item1 = new Item("Imported bottle of perfume", 1, 27.99, true, false);
            cart.AddItem(item1);

            Item item2 = new Item("Bottle of perfume", 1, 18.99, false, false);
            cart.AddItem(item2);

            Item item3 = new Item("Packet of headache pills", 1, 9.75, false, true);
            cart.AddItem(item3);

            Item item4 = new Item("Imported box of chocolates", 2, 11.25, true, true);
            cart.AddItem(item4);

            cart.Checkout();
        }
    }
}

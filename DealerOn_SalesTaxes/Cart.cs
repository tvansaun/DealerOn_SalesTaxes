using System;
using System.Collections.Generic;

namespace DealerOn_SalesTaxes
{
    public class Cart
    {
        List<Item> items;

        public Cart()
        {
            this.items = new List<Item>();
        }

        public void AddItem(Item i)
        {
            items.Add(i);

            //Confirm item added
            Console.WriteLine(i.GetQuantity() + " " + i.GetName() + " at " + i.GetPrice());
        }

        public void Checkout()
        {
            Console.WriteLine();
            Console.WriteLine("*******RECEIPT*******");

            double total = 0.00;
            double salesTax = 0.00;

            //Loop through all items in cart
            foreach(Item i in items)
            {
                //Calculate true total of item, add that to running total and sales tax
                double price = i.GetQuantity() * i.GetPrice();
                double tax = CalculateSalesTax(i);
                price += tax;
                total += price;
                salesTax += tax;

                //Print line item on receipt
                if(i.GetQuantity() > 1)
                {
                    Console.WriteLine(i.GetName() + ": " + price + " (" + i.GetQuantity() + " @ " + i.GetPrice() + ")");
                }
                else
                {
                    Console.WriteLine(i.GetName() + ": " + price);
                }

            }

            //Print totals
            Console.WriteLine("Sales Taxes: " + salesTax);
            Console.WriteLine("Total: " + total);
            
        }

        private static double CalculateSalesTax(Item item)
        {
            //price = price * quantity
            double price = (double)System.Math.Round(item.GetPrice() * item.GetQuantity(), 2);
            double tax = 0.00;

            //if item is imported then add 5% sales tax
            if (item.Imported())
            {
                tax += price * 0.05;
            }

            //if item is NOT tax exempt (it is not a book, food, or medical product), then add 10% sales tax
            if (!item.TaxExempt())
            {
                tax += price * 0.10;
            }

            //Round tax up to nearest $0.05
            tax = (double)System.Math.Ceiling(tax * 20.00) / 20.00;

            //Return tax rounded to 2 decimal places
            return (double)System.Math.Round(tax, 2);
        }
    }
}

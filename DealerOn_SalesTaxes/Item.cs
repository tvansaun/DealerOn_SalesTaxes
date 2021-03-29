using System;

namespace DealerOn_SalesTaxes
{
    public class Item
    {
        string name;
        int quantity;
        double price;
        bool isImported;
        bool isTaxExempt;

        public Item(string name, int quantity, double price, bool imported, bool exempt)
        {
            this.name = name;
            this.quantity = quantity;
            this.isImported = imported;
            this.isTaxExempt = exempt;
            this.price = price;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetQuantity()
        {
            return this.quantity;
        }

        public double GetPrice()
        {
            return this.price;
        }

        public bool Imported()
        {
            return this.isImported;
        }

        public bool TaxExempt()
        {
            return this.isTaxExempt;
        }

        
    }
}

using System;

namespace TellDontAskKata.Domain
{
    public class Product
    {
        private string name;
        private decimal price;
        private Category category;

        public decimal CalculateUnitaryTax()
        {
            return Math.Round((GetPrice() / 100) * (GetCategory().GetTaxPercentage()), 2, MidpointRounding.AwayFromZero);
        }

        public decimal CalculateUnitaryTaxedAmount(decimal unitaryTax)
        {
            return Math.Round(GetPrice() + unitaryTax, 2, MidpointRounding.AwayFromZero);
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }

        public Category GetCategory()
        {
            return category;
        }

        public void SetCategory(Category category)
        {
            this.category = category;
        }
    }
}
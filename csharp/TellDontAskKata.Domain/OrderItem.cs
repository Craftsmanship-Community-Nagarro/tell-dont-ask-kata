﻿using System;

namespace TellDontAskKata.Domain
{
    public class OrderItem
    {
        private Product product;
        private int quantity;
        private decimal taxedAmount;
        private decimal tax;

        public OrderItem(Product product, int quantity)
        {
            decimal unitaryTax = product.CalculateUnitaryTax();
            decimal taxedAmount = Math.Round(product.CalculateUnitaryTaxedAmount(unitaryTax) * quantity, 2, MidpointRounding.AwayFromZero);
            decimal taxAmount = Math.Round(unitaryTax * quantity, 2, MidpointRounding.AwayFromZero);

            SetProduct(product);
            SetQuantity(quantity);
            SetTax(taxAmount);
            SetTaxedAmount(taxedAmount);
        }

        public Product GetProduct()
        {
            return product;
        }

        public void SetProduct(Product product)
        {
            this.product = product;
        }

        public int getQuantity()
        {
            return quantity;
        }

        public void SetQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public decimal GetTaxedAmount()
        {
            return taxedAmount;
        }

        public void SetTaxedAmount(decimal taxedAmount)
        {
            this.taxedAmount = taxedAmount;
        }

        public decimal GetTax()
        {
            return tax;
        }

        public void SetTax(decimal tax)
        {
            this.tax = tax;
        }
    }
}
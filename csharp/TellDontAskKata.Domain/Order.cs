﻿using System;
using System.Collections.Generic;

namespace TellDontAskKata.Domain
{
    public class Order
    {
        private decimal total;
        private String currency;
        private List<OrderItem> items;
        private decimal tax;
        private OrderStatus status;
        private int id;

        public Order()
        {
            SetStatus(OrderStatus.Created);
            SetItems(new List<OrderItem>());
            SetTotal((decimal)0.0);
            SetCurrency("EUR");
            SetTax((decimal)0.0);
        }

        public void AddItem(OrderItem item)
        {
            GetItems().Add(item);

            if (HasTooManyFoodItems())
            {
                throw new MaximumNumberOfFoodItemsExceeded();
            }

            SetTotal(GetTotal() + item.GetTaxedAmount());
            SetTax(GetTax() + item.GetTax());
        }

        public bool HasTooManyFoodItems()
        {
            int numberOfFoodItems = 0;
            foreach (OrderItem item in GetItems())
            {
                if (item.GetProduct().GetCategory().GetName().Equals("food"))
                {
                    numberOfFoodItems += item.getQuantity();
                }
            }

            return numberOfFoodItems > 100;
        }

        public decimal GetTotal()
        {
            return total;
        }

        public void SetTotal(decimal total)
        {
            this.total = total;
        }

        public String GetCurrency()
        {
            return currency;
        }

        public void SetCurrency(String currency)
        {
            this.currency = currency;
        }

        public List<OrderItem> GetItems()
        {
            return items;
        }

        public void SetItems(List<OrderItem> items)
        {
            this.items = items;
        }

        public decimal GetTax()
        {
            return tax;
        }

        public void SetTax(decimal tax)
        {
            this.tax = tax;
        }

        public OrderStatus GetStatus()
        {
            return status;
        }

        public void SetStatus(OrderStatus status)
        {
            this.status = status;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}

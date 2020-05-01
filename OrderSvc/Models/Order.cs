﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Infrastructure.Extentions;

namespace OrderSvc.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        public string Currency { get; set; }
        public decimal Price => (LineItems.HasAny() ? LineItems.Sum(li => li.Qty * li.Price) : 0);
        public decimal Tax => 0.05M;
        public decimal Discount { get; set; }
        public decimal Shipping { get; set; }
        public decimal TotalPrice => Math.Round(Price * (1 + Tax) + Shipping - Discount, 2);
        public List<LineItem> LineItems { get; set; }
    }
}
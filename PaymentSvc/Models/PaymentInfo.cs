﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentSvc.Models
{
    public class PaymentInfo
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
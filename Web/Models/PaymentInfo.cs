﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public enum PaymentMethod
    {
        MasterCard,
        Visa,
        Amex
    }

    public class PaymentInfo
    {
        public string Id { get; set; }

        public string AccountId { get; set; }

        public bool IsDefault { get; set; }
        
        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        [StringLength(20)]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpDate { get; set; }

        [Required]
        [Range(1, 999)]
        public int CVV { get; set; }
    }
}

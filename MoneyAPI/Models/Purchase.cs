﻿using System;

namespace MoneyAPI.Models
{
    public class Purchase {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}

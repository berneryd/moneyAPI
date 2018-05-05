using System;

namespace MoneyAPI.Models
{
    public class Purchase {
        public int Id { get; set; }
        public string PurchasePlace { get; set; }
        public int PurchasePlaceId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}

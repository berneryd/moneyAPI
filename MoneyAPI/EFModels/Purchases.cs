using System;
using System.Collections.Generic;

namespace MoneyAPI.EFModels
{
    public partial class Purchases
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int Purchasename { get; set; }
        public DateTime Purchasedate { get; set; }
        public int Username { get; set; }
        public DateTime Insertiondate { get; set; }

        public PurchaseNames PurchasenameNavigation { get; set; }
        public Users UsernameNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MoneyAPI.EFModels
{
    public partial class PurchaseNames
    {
        public PurchaseNames()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte? Purchasetype { get; set; }
        public byte? Category { get; set; }

        public Categories CategoryNavigation { get; set; }
        public PurchaseBank PurchasetypeNavigation { get; set; }
        public ICollection<Purchases> Purchases { get; set; }
    }
}

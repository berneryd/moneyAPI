using System;
using System.Collections.Generic;

namespace MoneyAPI.EFModels
{
    public partial class Categories
    {
        public Categories()
        {
            PurchaseNames = new HashSet<PurchaseNames>();
        }

        public byte Id { get; set; }
        public string Category { get; set; }

        public ICollection<PurchaseNames> PurchaseNames { get; set; }
    }
}

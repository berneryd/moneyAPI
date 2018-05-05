using System;
using System.Collections.Generic;

namespace MoneyAPI.EFModels
{
    public partial class PurchaseBank
    {
        public PurchaseBank()
        {
            PurchaseNames = new HashSet<PurchaseNames>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public byte? Valuecolumn { get; set; }
        public byte? Datecolumn { get; set; }
        public byte? Namecolumn { get; set; }
        public byte? Categorycolumn { get; set; }

        public ICollection<PurchaseNames> PurchaseNames { get; set; }
    }
}

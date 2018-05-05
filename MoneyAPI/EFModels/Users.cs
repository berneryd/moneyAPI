using System;
using System.Collections.Generic;

namespace MoneyAPI.EFModels
{
    public partial class Users
    {
        public Users()
        {
            Purchases = new HashSet<Purchases>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Purchases> Purchases { get; set; }
    }
}

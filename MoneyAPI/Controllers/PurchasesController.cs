using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoneyAPI.EFModels;
using Newtonsoft.Json;
using MoneyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MoneyAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class PurchasesController : Controller
    {
        PurchaseHistoryContext dbContext;

        public PurchasesController(PurchaseHistoryContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Purchase> Get()
        {
            var purchases = this.dbContext.Purchases.Include(x => x.PurchasenameNavigation).Take(10);
            return purchases.Select(x => ConvertToModel(x));
        }

        [HttpGet("{id}")]
        public Purchase Get(int id)
        {
            var purchases = this.dbContext.Purchases.Include(x => x.PurchasenameNavigation).SingleOrDefault(x => x.Id == id);
            return ConvertToModel(purchases);
        }

        private Purchase ConvertToModel(Purchases purchase)
        {
            return new Purchase {
                Id = purchase.Id, 
                Description = purchase.PurchasenameNavigation.Name, 
                PurchaseDate = purchase.Purchasedate, 
                Amount = purchase.Amount
            };
        }
    }
}

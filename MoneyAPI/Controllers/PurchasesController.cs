using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoneyAPI.EFModels;
using MoneyAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using MoneyAPI.Filters;

namespace MoneyAPI.Controllers
{
    [CustomErrorFilter]
    [Route("api/[controller]")]
    public partial class PurchasesController : Controller
    {
        PurchaseHistoryContext dbContext;

        public PurchasesController(PurchaseHistoryContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var purchases = this.dbContext.Purchases.Include(x => x.PurchasenameNavigation.CategoryNavigation);
            var result = purchases.Select(x => ConvertToModel(x)).ToArray();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var purchases = this.dbContext.Purchases
                .Include(x => x.PurchasenameNavigation.CategoryNavigation)
                .SingleOrDefault(x => x.Id == id);

            if (purchases == null) {
                return NotFound();
            }

            return Ok(ConvertToModel(purchases));
        }

        private Purchase ConvertToModel(Purchases purchase)
        {
            return new Purchase {
                Id = purchase.Id, 
                PurchasePlace = purchase.PurchasenameNavigation.Name, 
                PurchasePlaceId = purchase.PurchasenameNavigation.Id,
                PurchaseDate = purchase.Purchasedate, 
                Amount = purchase.Amount, 
                Category = purchase.PurchasenameNavigation.CategoryNavigation.Category,
                CategoryId = purchase.PurchasenameNavigation.CategoryNavigation.Id
            };
        }
    }
}

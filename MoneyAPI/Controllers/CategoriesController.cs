using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoneyAPI.EFModels;
using MoneyAPI.Models;

namespace MoneyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        PurchaseHistoryContext dbContext;

        public CategoriesController(PurchaseHistoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var purchases = this.dbContext.Categories;
            return Ok(purchases.Select(x => ConvertToModel(x)));
        }

        private Category ConvertToModel(Categories category)
        {
            return new Category { Id = category.Id, Name = category.Category };
        }
    }
}
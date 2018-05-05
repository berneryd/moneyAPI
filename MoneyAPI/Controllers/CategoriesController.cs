using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyAPI.EFModels;
using MoneyAPI.Models;
using Newtonsoft.Json;

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
        public IEnumerable<Category> Get()
        {
            var purchases = this.dbContext.Categories;
            return purchases.Select(x => ConvertToModel(x));
        }

        private Category ConvertToModel(Categories category)
        {
            return new Category { Id = category.Id, Name = category.Category };
        }
    }
}
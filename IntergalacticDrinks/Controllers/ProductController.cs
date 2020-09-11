using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntergalacticDrinks.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntergalacticDrinks.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Product"] = "active";
            return View(DataAccessModel.GetAllCategories());
        }

        public IActionResult Category(int CategoryId)
        {
            ViewData["Category"] = DataAccessModel.GetCategory(CategoryId);
            return View(DataAccessModel.GetProducts(CategoryId));
        }

        public IActionResult Detail(int ProductId)
        {
            return View(DataAccessModel.GetProduct(ProductId));
        }
    }
}

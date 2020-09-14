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

        public IActionResult Category(int id)
        {
            ViewData["Category"] = DataAccessModel.GetCategory(id);
            return View(DataAccessModel.GetProducts(id));
        }

        public IActionResult Detail(int id)
        {
            return View(DataAccessModel.GetProduct(id));
        }
    }
}

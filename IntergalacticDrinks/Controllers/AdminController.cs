using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntergalacticDrinks.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntergalacticDrinks.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View(DataAccessModel.GetAllProducts());
        }

        [HttpGet]
        public IActionResult Modify(int id)
        {
            AdminControlModel m = new AdminControlModel()
            {
                NewProduct = (id == -1)
            };
            if(!m.NewProduct)
            {
                m.CurrentProduct = DataAccessModel.GetProduct(id);
            }
            return View(m);
        }

        [HttpPost]
        public IActionResult Modify(long id, string name, string shortDescription, string longDescription, decimal price, int category)
        {
            bool created;
            if(id < 1)
            {
                //insert new product
                id = DataAccessModel.AddProduct(name, shortDescription, longDescription, price, category);
                created = true;
            }
            else
            {
                //update existing product
                DataAccessModel.UpdateProduct(id, name, shortDescription, longDescription, price, category);
                created = false;
            }

            //redirect to summary page
            return RedirectToAction("Summary", "Admin", new { created, id});
        }

        public IActionResult Summary(bool created, long id)
        {
            Product model = DataAccessModel.GetProduct(id);
            ViewData["Category"] = DataAccessModel.GetCategory(model.CategoryId);
            ViewData["Created"] = created;
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            DataAccessModel.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}

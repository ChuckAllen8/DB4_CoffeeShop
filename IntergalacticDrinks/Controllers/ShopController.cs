using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntergalacticDrinks.Models;

namespace IntergalacticDrinks.Controllers
{
    public class ShopController : Controller
    {

        private LoggedInUserModel CreateUser(string First_Name, string Last_Name, string Email, string Home_Planet, string Current_Captain)
        {
            LoggedInUserModel m = new LoggedInUserModel();
            m.values[LoggedInUserModel.FIRST_NAME] = First_Name;
            m.values[LoggedInUserModel.LAST_NAME] = Last_Name;
            m.values[LoggedInUserModel.EMAIL] = Email;
            m.values[LoggedInUserModel.HOME_PLANET] = Home_Planet;
            m.values[LoggedInUserModel.CURRENT_CAPTAIN] = Current_Captain;

            return m;
        }

        [HttpPost]
        public IActionResult Index(string First_Name, string Last_Name, string Email, string Home_Planet, string Current_Captain, string orderID)
        {
            LoggedInUserModel user = CreateUser(First_Name, Last_Name, Email, Home_Planet, Current_Captain);
            ShopModel shop;
            if (orderID is null || orderID == "")
            {
                shop = new ShopModel(user);
            }
            else
            {
                shop = new ShopModel(user, int.Parse(orderID));
            }
            
            return View(shop);
        }

        [HttpPost]
        public IActionResult Summary(string First_Name, string Last_Name, string Email, string Home_Planet, string Current_Captain, string orderID, string delivery, string time, string address1, string address2, string addressCity, string addressState, string addressZip, string drinks, string sizes, string whippedCream)
        {
            LoggedInUserModel user = CreateUser(First_Name, Last_Name, Email, Home_Planet, Current_Captain);
            ShopModel shop;

            if (orderID is null || orderID == "")
            {
                shop = new ShopModel(user);
            }
            else
            {
                shop = new ShopModel(user, int.Parse(orderID));
            }
            shop.WhippedTopping = whippedCream is null ? false : true;
            shop.Pickup = delivery;
            shop.Drink = drinks;
            shop.Size = sizes;
            shop.Address1 = address1;
            shop.Address2 = address2;
            shop.City = addressCity;
            shop.State = addressState;
            shop.Zip = addressZip;
            shop.Time = time;
            return View(shop);
        }
    }
}

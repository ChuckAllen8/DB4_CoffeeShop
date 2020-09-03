using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IntergalacticDrinks.Models;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace IntergalacticDrinks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        private WebUserModel Model(string First_Name, string Last_Name, string Username, string Password, string Re_Enter_Password, string Email, string Home_Planet, string Current_Captain)
        {
            WebUserModel m = new WebUserModel();
            m.values[WebUserModel.FIRST_NAME] = First_Name;
            m.values[WebUserModel.LAST_NAME] = Last_Name;
            m.values[WebUserModel.USERNAME] = Username;
            m.values[WebUserModel.PASSWORD] = Password;
            m.values[WebUserModel.RE_ENTER_PASSWORD] = Re_Enter_Password;
            m.values[WebUserModel.EMAIL] = Email;
            m.values[WebUserModel.HOME_PLANET] = Home_Planet;
            m.values[WebUserModel.CURRENT_CAPTAIN] = Current_Captain;

            return m;
        }

        private WebUserModel ModelErrors(string First_Name, string Last_Name, string Username, string Password, string Re_Enter_Password, string Email, string Home_Planet, string Current_Captain)
        {
            WebUserModel m = Model(First_Name, Last_Name, Username, Password, Re_Enter_Password, Email, Home_Planet, Current_Captain);
            BadEntry(m);
            return m;
        }

        private bool BadInput(string field, string val)
        {
            return field switch
            {
                "First_Name" => !(!(val is null) && val != ""),
                "Last_Name" => !(!(val is null) && val != ""),
                "Username" => !(!(val is null) && val != ""),
                "Password" => !(!(val is null) && val != "" && Regex.IsMatch(val, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$")),
                "Email" => !(!(val is null) && val != "" && Regex.IsMatch(val, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")),
                "Home_Planet" => !(!(val is null) && val != ""),
                "Current_Captain" => !(!(val is null) && val != ""),
                _ => true,
            };
        }

        public IActionResult Register(string First_Name, string Last_Name, string Username, string Password, string Re_Enter_Password, string Email, string Home_Planet, string Current_Captain)
        {
            if(HttpContext.Request.Method == "GET")
            {
                return View(Model(First_Name, Last_Name, Username, Password, Re_Enter_Password, Email, Home_Planet, Current_Captain));
            }
            else
            {
                return View(ModelErrors(First_Name, Last_Name, Username, Password, Re_Enter_Password, Email, Home_Planet, Current_Captain));
            }
        }

        [HttpPost]
        public IActionResult RegistrationCompleted(string First_Name, string Last_Name, string Username, string Password, string Re_Enter_Password, string Email, string Home_Planet, string Current_Captain)
        {
            if(BadEntry(Model(First_Name, Last_Name, Username, Password, Re_Enter_Password, Email, Home_Planet, Current_Captain)))
            {
                return RedirectToActionPreserveMethod("Register", "Home");
            }

            return View(Model(First_Name, Last_Name, Username, Password, Re_Enter_Password, Email, Home_Planet, Current_Captain));
        }

        private bool BadEntry(WebUserModel m)
        {
            for (int index = 0; index < m.fields.Count; index++)
            {
                if (m.fields[index] != "Re_Enter_Password")
                {
                    m.fieldError[index] = BadInput(m.fields[index], m.values[index]);
                }
                else
                {
                    m.fieldError[index] = (m.values[index] != m.values[index-1]);
                }
            }
            return m.fieldError.Contains(true);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

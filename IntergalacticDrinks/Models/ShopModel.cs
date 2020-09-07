using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticDrinks.Models
{
    public class ShopModel
    {
        public LoggedInUserModel Shopper;
        public int OrderID { get; private set; }

        public string Drink { get; set; }

        public string Size { get; set; }

        public bool WhippedTopping { get; set; }

        public string Pickup { get; set; }

        public string Time { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string FullAddress
        {
            get
            {
                string full = "";
                full += Address1 + "<br />";
                if(!(Address2 is null) && Address2 != "")
                {
                    full += Address2 + "<br />";
                }
                full += City + ", " + State + " " + Zip + "<br />";
                return full;
            }
        }

        public ShopModel(LoggedInUserModel user)
        {
            OrderID = new Random().Next(10000, 100000);
            Shopper = user;
        }

        public ShopModel(LoggedInUserModel user, int id)
        {
            OrderID = id;
            Shopper = user;
        }
    }
}

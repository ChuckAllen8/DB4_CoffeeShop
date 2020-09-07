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

        public string EstimatedDelivery
        {
            get
            {
                return (DateTime.Now.AddMinutes(25)).ToString();
            }
        }

        public string PickupTime
        {
            get
            {
                DateTime now = DateTime.Now;
                return (new DateTime(now.Year, now.Month, now.Day, int.Parse(Time.Split(":")[0]), int.Parse(Time.Split(":")[1]), 0)).ToString();
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

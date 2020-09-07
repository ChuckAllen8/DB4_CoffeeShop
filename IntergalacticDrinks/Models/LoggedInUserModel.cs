using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticDrinks.Models
{
    public class LoggedInUserModel
    {
        public const int FIRST_NAME = 0;
        public const int LAST_NAME = 1;
        public const int EMAIL = 2;
        public const int HOME_PLANET = 3;
        public const int CURRENT_CAPTAIN = 4;

        public List<string> fields;
        public List<string> values;
        public List<string> types;

        public LoggedInUserModel()
        {
            fields = new List<string>()
            {
                "First_Name", "Last_Name", "Email", "Home_Planet", "Current_Captain"
            };

            types = new List<string>()
            {
                "text", "text", "email", "text", "text"
            };

            values = new List<string>()
            {
                "", "", "", "", ""
            };
        }
    }
}

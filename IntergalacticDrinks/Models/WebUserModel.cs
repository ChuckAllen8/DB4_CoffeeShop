using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticDrinks.Models
{
    public class WebUserModel
    {
        public const int FIRST_NAME = 0;
        public const int LAST_NAME = 1;
        public const int USERNAME = 2;
        public const int PASSWORD = 3;
        public const int RE_ENTER_PASSWORD = 4;
        public const int EMAIL = 5;
        public const int HOME_PLANET = 6;
        public const int CURRENT_CAPTAIN = 7;

        public List<string> fields;
        public List<bool> fieldError;
        public List<string> fieldErrorMessage;
        public List<string> values;
        public List<string> types;

        public WebUserModel()
        {
            fields = new List<string>()
            {
                "First_Name", "Last_Name", "Username", "Password", "Re_Enter_Password", "Email", "Home_Planet", "Current_Captain"
            };

            fieldErrorMessage = new List<string>()
            {
                "Cannot be blank", "Cannot be blank", "Cannot be blank", "Characters: 8, 1 upper, 1 lower, 1 number", "Must match password", "Must be a valid email", "Cannot be blank", "Cannot be blank"
            };

            fieldError = new List<bool>()
            {
                false, false, false, false, false, false, false, false
            };

            types = new List<string>()
            {
                "text", "text", "text", "password", "password", "email", "text", "text"
            };

            values = new List<string>()
            {
                "", "", "", "", "", "", "", ""
            };
        }
    }
}

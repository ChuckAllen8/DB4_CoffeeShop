using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntergalacticDrinks.Models
{
    public class AdminControlModel
    {
        public bool NewProduct { get; set; }

        public Product CurrentProduct { get; set; }

        public List<Category> AvailableCategories { get
            {
                return DataAccessModel.GetAllCategories();
            } }
    }
}

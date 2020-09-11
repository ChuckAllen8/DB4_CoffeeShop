using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace IntergalacticDrinks.Models
{
    public class DataAccessModel
    {
        private static List<T> ExecuteQuery<T>(string query)
        {
            List<T> results;
            using (IDbConnection db = new SqlConnection("Server=7K5SN13\\DB4_SERVER;Database=CoffeeShop;user id=DB4_Coffee;password=pass1"))
            {
                results = db.Query<T>(query).AsList<T>();
            }
            return results;
        }

        public static List<Category> GetAllCategories()
        {
            return ExecuteQuery<Category>("SELECT * FROM Category");
        }

        public static string GetCategory(int CategoryId)
        {
            return ExecuteQuery<Category>("SELECT * FROM Category WHERE Id = " + CategoryId)[0].Name;
        }

        public static List<Product> GetProducts(int CategoryId)
        {
            return ExecuteQuery<Product>("SELECT * FROM Product WHERE CategoryId = " + CategoryId);
        }

        public static Product GetProduct(int ProductId)
        {
            string query = "SELECT * FROM Product WHERE Id = " + ProductId;
            return ExecuteQuery<Product>(query)[0];
        }
    }
}

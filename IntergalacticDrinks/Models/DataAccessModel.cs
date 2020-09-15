using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;

namespace IntergalacticDrinks.Models
{
    public class DataAccessModel
    {

        private static IDbConnection GetDBConnection()
        {
            return new SqlConnection("Server=7K5SN13\\DB4_SERVER;Database=CoffeeShop;user id=DB4_Coffee;password=pass1");
        }

        private static List<T> ExecuteQuery<T>(string query)
        {
            List<T> results;
            using (IDbConnection db = GetDBConnection())
            {
                results = db.Query<T>(query).AsList<T>();
            }
            return results;
        }

        private static void ExecuteQuery(string query)
        {
            using (IDbConnection db = GetDBConnection())
            {
                db.Execute(query);
            }
        }

        public static List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            return ExecuteQuery<Category>(query);
        }

        public static string GetCategory(int CategoryId)
        {
            string query = "SELECT * FROM Category WHERE Id = " + CategoryId;
            return ExecuteQuery<Category>(query)[0].Name;
        }

        public static List<Product> GetProducts(int CategoryId)
        {
            string query = "SELECT * FROM Product WHERE CategoryId = " + CategoryId;
            return ExecuteQuery<Product>(query);
        }

        public static List<Product> GetAllProducts()
        {
            string query = "SELECT * FROM Product";
            return ExecuteQuery<Product>(query);
        }

        public static Product GetProduct(long ProductId)
        {
            string query = "SELECT * FROM Product WHERE Id = " + ProductId;
            return ExecuteQuery<Product>(query)[0];
        }

        public static void Delete(int id)
        {
            string query = "DELETE FROM Product WHERE Id = " + id;
            ExecuteQuery(query);
        }

        public static long AddProduct(string name, string shortDescription, string longDescription, decimal price, int category)
        {
            Product product = new Product()
            {
                Name = name,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                Price = price,
                CategoryId = category
            };
            IDbConnection db = GetDBConnection();
            return db.Insert(product);
        }

        public static void UpdateProduct(long id, string name, string shortDescription, string longDescription, decimal price, int category)
        {
            Product product = new Product()
            {
                Id = id,
                Name = name,
                ShortDescription = shortDescription,
                LongDescription = longDescription,
                Price = price,
                CategoryId = category
            };
            IDbConnection db = GetDBConnection();
            db.Update(product);
        }
    }
}

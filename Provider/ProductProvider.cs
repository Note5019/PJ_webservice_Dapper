using Dapper;
using PJ_webservice_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_webservice_Dapper.Interfaces
{
    public interface IProductProvider
    {
        IEnumerable<Product> Get(SearchProduct searchReq);
        IEnumerable<Product> GetByID(string productID);
    }

    public class ProductProvider : IProductProvider
    {
        private readonly string connectionString;
        public ProductProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Product> Get(SearchProduct searchReq)
        {
            IEnumerable<Product> product = null;
            using (var connection = new SqlConnection(connectionString))
            {
                //product = connection.Query<Product>("SELECT * FROM products;");
                string qryStr = $"EXEC getProducts @ProductID,@ProductName,@CatID,@PriceFrom,@PriceTo;";
                product = connection.Query<Product>(qryStr, searchReq);
            }
            return product;
        }

        public IEnumerable<Product> GetByID(string productID)
        {
            IEnumerable<Product> product = null;
            using (var connection = new SqlConnection(connectionString))
            {
                //product = connection.Query<Product>("SELECT * FROM products;");
                string qryStr = $"EXEC getProductByID '{productID}';";
                product = connection.Query<Product>(qryStr);
            }
            return product;
        }
    }
}

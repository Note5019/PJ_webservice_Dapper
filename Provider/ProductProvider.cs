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
            using(var connection = new SqlConnection(connectionString))
            {
                //product = connection.Query<Product>("SELECT * FROM products;");
                string qryStr = $"EXEC getProducts '{searchReq.ProductID}','{searchReq.ProductName}','{searchReq.CatID}',{searchReq.PriceFrom},{searchReq.PriceTo};";
                product = connection.Query<Product>(qryStr);
            }
            return product;
        }
    }
}

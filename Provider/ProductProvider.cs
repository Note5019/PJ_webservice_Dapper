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
        Response Insert(Product data);
        Response Update(string productID,Product product);
        Response Delete(string productID);
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
                string qryStr = $"EXEC getProductByID @productID;";
                product = connection.Query<Product>(qryStr, new { productID });
            }
            return product;
        }

        public Response Insert(Product product)
        {
            int row = -1;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    //product = connection.Query<Product>("SELECT * FROM products;");
                    string qryStr = $"EXEC insertProduct  @ProductID,@ProductName,@CatID,@Price,@Amount,@ImgURL;";
                    row = connection.Execute(qryStr, product);
                }
                return new Response("success", row);
            }
            catch(Exception err)
            {
                return new Response(err.Message, row);

            }
        }
        public Response Update(string productID,Product product)
        {
            int row = -1;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    //product = connection.Query<Product>("SELECT * FROM products;");
                    string qryStr = $"EXEC updateProduct  @ProductID,@ProductName,@CatID,@Price,@Amount,@ImgURL;";
                    product.ProductID = productID;
                    row = connection.Execute(qryStr, product);
                }
                return new Response("success", row);
            }
            catch(Exception err)
            {
                return new Response(err.Message, row);

            }
        }
        public Response Delete(string productID)
        {
            int row = -1;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    //product = connection.Query<Product>("SELECT * FROM products;");
                    string qryStr = $"EXEC deleteProduct  @ProductID";
                    row = connection.Execute(qryStr, new { productID });
                }
                return new Response("success", row);
            }
            catch (Exception err)
            {
                return new Response(err.Message, row);

            }
        }
    }
}

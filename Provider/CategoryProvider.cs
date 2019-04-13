using Dapper;
using PJ_webservice_Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_webservice_Dapper.Provider
{
    public interface ICategoryProvider
    {
        IEnumerable<Category> Get();
    }
    public class CategoryProvider : ICategoryProvider
    {
        private readonly string connectionString;
        public CategoryProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Category> Get()
        {
            IEnumerable<Category> category = null;
            using (var connection = new SqlConnection(connectionString))
            {
                string qryStr = $"SELECT * FROM categories";
                category = connection.Query<Category>(qryStr);
            }
            return category;
        }
    }
}

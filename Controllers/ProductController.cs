using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_webservice_Dapper.Interfaces;
using PJ_webservice_Dapper.Models;

namespace PJ_webservice_Dapper.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductProvider productProvider;
        public ProductController(IProductProvider productProvider)
        {
            this.productProvider = productProvider;
        }
        
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get([FromBody] SearchProduct searchReq)
        {
            return productProvider.Get(searchReq);
        }

        // GET: api/Product/5
        [HttpGet("{productID}", Name = "GetProductID")]
        public IEnumerable<Product> Get(string productID)
        {
            return productProvider.GetByID(productID);
        }

        // POST: api/Product
        [HttpPost]
        public Response Post([FromBody] Product data)
        {
            return productProvider.Insert(data);
        }

        // PUT: api/Product/5
        [HttpPut("{productID}")]
        public Response Put(string productID, [FromBody] Product data)
        {
            return productProvider.Update(productID,data);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{productID}")]
        public Response Delete(string productID)
        {
            return productProvider.Delete(productID);
        }
    }
}

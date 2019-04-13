using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PJ_webservice_Dapper.Models;
using PJ_webservice_Dapper.Provider;

namespace PJ_webservice_Dapper.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryProvider categoryProvider;
        public CategoryController(ICategoryProvider categoryProvider)
        {
            this.categoryProvider = categoryProvider;
        }
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryProvider.Get();
        }

        // GET: api/Category/5
        [HttpGet("{categoryID}", Name = "GetCategoryID")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

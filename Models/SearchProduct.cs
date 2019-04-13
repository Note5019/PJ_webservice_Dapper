using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_webservice_Dapper.Models
{
    public class SearchProduct
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CatID { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
    }
}

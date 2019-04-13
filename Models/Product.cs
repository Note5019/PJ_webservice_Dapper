using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_webservice_Dapper.Models
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CatID { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public string ImgURL { get; set; }
    }
}

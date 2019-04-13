using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJ_webservice_Dapper.Models
{
    public class Response
    {
        public Response(string strRes, int rowAffected)
        {
            this.strRes = strRes;
            this.rowAffected = rowAffected;
        }
        public string strRes { get; set; }
        public int rowAffected { get; set; }
    }
}

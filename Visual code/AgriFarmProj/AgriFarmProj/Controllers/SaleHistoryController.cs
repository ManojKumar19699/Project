using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class SaleHistoryController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage getSaleHistory([FromUri] int Id, string usertype)
        {
            using (var db = new dbProjectEntities())
            {
                if (usertype.Equals("farmer"))
                {
                    List<sp_salehistoryfarmer_Result> res = db.sp_salehistoryfarmer(Id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, res);
                }
                else if (usertype.Equals("bidder"))
                {
                    List<sp_saleshistory_Result> res1 = db.sp_saleshistory(Id).ToList();
                    return Request.CreateResponse(HttpStatusCode.OK, res1);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
        }
    }
}

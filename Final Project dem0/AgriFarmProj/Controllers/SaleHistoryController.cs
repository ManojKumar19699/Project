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
        public HttpResponseMessage getSaleHistory([FromUri] int id, string usertype)
        {
            using (var db = new dbProjectEntities())
            {
                if (usertype.Equals("farmer"))
                {
                    var sales = (from s in db.tblSales
                                 where s.FarmerId == id && s.ApprovalAdminId != null
                                 select s).ToList();

                    if (sales.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, sales);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found");
                    }
                }
                else if (usertype.Equals("bidder"))
                {
                    var sales = (from s in db.tblSales
                                 where s.BidderId == id && s.ApprovalAdminId != null
                                 select s).ToList();

                    if (sales.Count > 0)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, sales);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }

            }
        }
    }
}

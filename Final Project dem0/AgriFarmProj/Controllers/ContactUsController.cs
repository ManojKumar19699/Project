using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class ContactUsController : ApiController
    {
        dbProjectEntities db = new dbProjectEntities();

        [HttpPost]
        public void Post([FromBody] tblContactU contactU)
        {
            try
            {
                tblContactU c = new tblContactU();
                c.ContactName = contactU.ContactName;
                c.Email = contactU.Email;
                c.RequestType = contactU.RequestType;
                c.message = contactU.message;
                c.status = "Not Seen";
                c.ApprovalAdminId = null;

                db.tblContactUs.Add(c);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetMsg()
        {
            var msg = db.tblContactUs.ToList();
            if (msg.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, msg);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Data not found");
            }
        }
    }
}

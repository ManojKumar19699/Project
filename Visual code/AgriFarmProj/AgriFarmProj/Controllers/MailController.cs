using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AgriFarmProj.Models;
using System.Net.Mail;
using AgriFarmProj.Models.ViewModel;

namespace AgriFarmProj.Controllers
{
    public class MailController : ApiController
    {

        dbProjectEntities db = new dbProjectEntities();

        [HttpPost]
        public async Task<HttpResponseMessage> SendEmail([FromBody] Email email)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("<" + email.To + ">"));
            message.From = new MailAddress("AgriFarm <manojkumar19699@gmail.com>");
            message.Subject = email.Subject;
            message.Body = email.Body;
            message.IsBodyHtml = true;
            try
            {
                var smtp = new SmtpClient();
                await smtp.SendMailAsync(message);
                return Request.CreateResponse(HttpStatusCode.OK, ("mail sent", email.To));
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }


        [HttpPost]
        [Route("approvalmail")]
        public async Task<HttpResponseMessage> ApprovalEmail([FromUri] string to)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("<" + to + ">"));
            message.From = new MailAddress("AgriFarm <manojkumar19699@gmail.com>");
            message.Subject = "User Approval";
            message.Body = "<b><h2>Hello</h2> " + to + ",</b><br><h3> You are now an approved user for AgriFarm! Please continue to our site by login</h3>";
            message.IsBodyHtml = true;
            try
            {
                var smtp = new SmtpClient();
                await smtp.SendMailAsync(message);
                return Request.CreateResponse(HttpStatusCode.OK, "mail sent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        [Route("claimapproval")]
        public async Task<HttpResponseMessage> ClaimApproval([FromUri] int policyno)
        {
            try
            {
                var user = (from f in db.tblFarmers
                            join i in db.tblInsurances
                            on f.FarmerId equals i.FarmerId
                            where i.PolicyNo == policyno
                            select f.FarmerEmail).ToList();
                var message = new MailMessage();
                message.To.Add(new MailAddress("<" + user[0] + ">"));
                message.From = new MailAddress("AgriFarm <manojkumar19699@gmail.com>");
                message.Subject = "Claim Approval";
                message.Body = "<b><h2>Hello</h2> " + user[0] + ",</b><br><h3>For the policy number <b>" + policyno + "</b>, your claim has been approved!</h3>";
                message.IsBodyHtml = true;

                var smtp = new SmtpClient();
                await smtp.SendMailAsync(message);
                return Request.CreateResponse(HttpStatusCode.OK, "mail sent");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
            }
        }

        /*        [HttpPut]
                public IHttpActionResult ChangeStatus([FromUri] string mail,int id)
                {
                    using(var db=new dbProjectEntities1())
                    {
                        var currentmsg = db.tblContactUs.Where(c => c.Email.Equals(mail))
                            .FirstOrDefault<tblContactU>();
                        if (currentmsg != null)
                        {
                            currentmsg.status = "Replied";
                            currentmsg.ApprovalAdminId = id;
                            db.SaveChanges();
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    return Ok();
                }
        */

        [Route("api/EmailSent/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] string mail, int id)
        {
            var currentmsg = db.tblContactUs.Where(c => c.Email.Equals(mail))
                   .FirstOrDefault<tblContactU>();
            if (currentmsg != null)
            {
                currentmsg.status = "Replied";
                currentmsg.ApprovalAdminId = id;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

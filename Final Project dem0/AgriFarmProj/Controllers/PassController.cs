using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class PassController : ApiController
    {
        dbProjectEntities db = new dbProjectEntities();
        //[System.Web.Http.AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpGet]
        public bool CheckEmail(string email)
        {
            var isValidFarmerEmail = db.tblFarmers.Where(w => w.FarmerEmail == email).FirstOrDefault();
            var isValidBidderEmail = db.tblBidders.Where(w => w.BidderEmail == email).FirstOrDefault();
            if (isValidFarmerEmail != null)
            {
                return true;
            }
            else if (isValidBidderEmail != null)
            {
                return true;
            }
            return false;
        }

        [Route("send-email")]
        [HttpGet]
        public async Task<int> SendEmail(string to)
        {
            if (CheckEmail(to) == true)
            {

                string from = "muskanparlani30@gmail.com";
                string subject = "Welcome to AgriFarm";
                Random generator = new Random();    
                int r = generator.Next(1000, 10000);
                string body = "Hello , Your otp is " + r;

                SmtpClient smtp = new SmtpClient();

                MailMessage mm = new MailMessage();
                mm.From = new MailAddress(from);
                mm.To.Add(to);
                mm.Subject = subject;
                mm.Body = body;
                await Task.Run(() => smtp.SendAsync(mm, null));
                return r;
            }
            else
            {
                return 0;
            }

        }
        [Route("update-password")]
        [HttpPut]
        public dynamic UpdatePassword(string email, string password)
        {

            List<tblFarmer> far = db.tblFarmers.ToList();
            List<tblBidder> bid = db.tblBidders.ToList();

            foreach (var item in far)
            {

                if (item.FarmerEmail == email)
                {
                    item.FarmerPassword = password;
                    byte[] encData_byte = new byte[item.FarmerPassword.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(item.FarmerPassword);
                    string encodedpassword = Convert.ToBase64String(encData_byte);
                    item.FarmerPassword = encodedpassword;

                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Valid");
                }

            }

            foreach (var item in bid)
            {
                if (item.BidderEmail == email)
                {
                    item.BidderPassword = password;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Valid");
                }

            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "NotFound");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using AgriFarmProj.Models;
using System.IO;

namespace AgriFarmProj.Controllers
{
    public class BidderRegController : ApiController
    {

        int bid;

        dbProjectEntities db = new dbProjectEntities();

        [HttpPost]
        [Route("RegBidder")]
        public IHttpActionResult WayTwo()
        {
            string imageName = "";
            string imageName1 = "";

            string Qty = "";
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            var postedFile1 = httpRequest.Files["Image1"];

            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            imageName1 = new String(Path.GetFileNameWithoutExtension(postedFile1.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName1 = imageName1 + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile1.FileName);
            var filePath1 = HttpContext.Current.Server.MapPath("~/Image/" + imageName1);
            postedFile1.SaveAs(filePath1);


            tblBidder br = new tblBidder();
            //Save to DB
            using (dbProjectEntities db = new dbProjectEntities())
            {
                List<tblBidder> bidders = db.tblBidders.ToList();
                List<tblBank> banks = db.tblBanks.ToList();

                foreach (tblBidder tblBidder1 in bidders)
                {
                    if (tblBidder1.BidderEmail == httpRequest["BidderEmail"]) return Ok("Email");
                }

                foreach (tblBank tblBank1 in banks)
                {
                    if (tblBank1.AccountNo == httpRequest["AccountNo"]) return Ok("Account");
                }

                try
                {
                    #region saving details into db
                    br.BidderAadhar = imageName;
                    br.BidderTradeLicense = imageName1;

                    br.BidderName = httpRequest["BidderName"];
                    br.BidderEmail = httpRequest["BidderEmail"];
                    br.BidderContactNo = httpRequest["BidderContactNo"];
                    br.BidderAddress = httpRequest["BidderAddress"];
                    br.BidderCity = httpRequest["BidderCity"];
                    br.BidderState = httpRequest["BidderState"];
                    br.BidderPincocde = httpRequest["BidderPincocde"];
                    br.BidderPassword = httpRequest["BidderPassword"];
                    byte[] encData_byte = new byte[br.BidderPassword.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(br.BidderPassword);
                    string encodedpassword = Convert.ToBase64String(encData_byte);
                    br.BidderPassword = encodedpassword;

                    br.BidderApproved = false;
                    db.tblBidders.Add(br);
                    db.SaveChanges();

                    List<tblBidder> res = db.tblBidders.ToList();
                    foreach (tblBidder item in res)
                    {
                        if (item.BidderEmail == br.BidderEmail)
                        {
                            bid = item.BidderId;
                            break;
                        }
                    }

                    tblBank tb1 = new tblBank();
                    tb1.FarmerId = null;
                    tb1.AccountNo = httpRequest["AccountNo"];
                    tb1.IFSC_Code = httpRequest["IFSC_Code"];
                    tb1.BidderId = bid;

                    db.tblBanks.Add(tb1);
                    db.SaveChanges();
                    #endregion
                }
                catch
                {
                    return Ok("Error");
                }
            }
            return Ok("OK");

        }
    }
}

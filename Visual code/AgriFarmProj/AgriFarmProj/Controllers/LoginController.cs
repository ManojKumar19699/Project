using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;
using AgriFarmProj.Models.ViewModel;

namespace AgriFarmProj.Controllers
{
    public class LoginController : ApiController
    {
        dbProjectEntities db = new dbProjectEntities();
        [Route("checkLogin")]
        public HttpResponseMessage CheckLogin([FromBody] Login login)
        {
            if (login.UserType.Equals("Admin"))
            {
                List<tblAdmin> admin = new List<tblAdmin>();
                admin = (from a in db.tblAdmins
                         where login.Email.Equals(a.AdminEmail)
                         select a).ToList();

                if (admin.Count > 0)
                {
                    if (login.Password.Equals(admin[0].AdminPass))
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, ("admin", admin[0].AdminEmail));
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "wrong credentials");
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "not registered");
                }
            }
            else if (login.UserType.Equals("Farmer"))
            {
                List<tblFarmer> farmer = new List<tblFarmer>();
                farmer = (from f in db.tblFarmers
                          where login.Email.Equals(f.FarmerEmail)
                          select f).ToList();
                if (farmer.Count > 0)
                {
                    if (farmer[0].FarmerApproved == true)
                    {
                        #region decrypt for farmer
                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        System.Text.Decoder utf8Decode = encoder.GetDecoder();
                        byte[] todecode_byte = Convert.FromBase64String(farmer[0].FarmerPassword);
                        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                        char[] decoded_char = new char[charCount];
                        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                        string pass = new String(decoded_char);
                        #endregion

                        if (login.Password.Equals(pass))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, ("farmer", farmer[0].FarmerEmail));
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "wrong credentials");
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "not approved");
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "not registered");
                }
            }
            else if (login.UserType.Equals("Bidder"))
            {
                List<tblBidder> bidder = new List<tblBidder>();
                bidder = (from b in db.tblBidders
                          where login.Email.Equals(b.BidderEmail)
                          select b).ToList();
                if (bidder.Count > 0)
                {
                    if (bidder[0].BidderApproved == true)
                    {
                        #region decrypt for bidder
                        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                        System.Text.Decoder utf8Decode = encoder.GetDecoder();
                        byte[] todecode_byte = Convert.FromBase64String(bidder[0].BidderPassword);
                        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                        char[] decoded_char = new char[charCount];
                        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                        string pass = new String(decoded_char);
                        #endregion

                        if (login.Password.Equals(pass))
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, ("bidder", bidder[0].BidderEmail));
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, "wrong credentials");
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "not approved");
                    }

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "not registered");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }


        [Route("api/GetId")]
        public HttpResponseMessage Getid([FromUri] string email, string user)
        {
            if (user == "admin")
            {
                List<tblAdmin> resadmin = db.tblAdmins.ToList();
                tblAdmin outputadmin = new tblAdmin();
                foreach (tblAdmin item in resadmin)
                {
                    if (item.AdminEmail.Equals(email)) { outputadmin = item; break; }
                }
                return Request.CreateResponse(HttpStatusCode.OK, outputadmin.AdminId);
            }
            if (user == "farmer")
            {
                List<tblFarmer> res = db.tblFarmers.ToList();

                tblFarmer output = new tblFarmer();
                foreach (tblFarmer item in res)
                {
                    if (item.FarmerEmail == email) { output = item; break; }
                }
                return Request.CreateResponse(HttpStatusCode.OK, output.FarmerId);
            }

            List<tblBidder> resbid = db.tblBidders.ToList();

            tblBidder outputbid = new tblBidder();
            foreach (tblBidder item in resbid)
            {
                if (item.BidderEmail.Equals(email)) { outputbid = item; break; }
            }
            return Request.CreateResponse(HttpStatusCode.OK, outputbid.BidderId);


        }
    }
}

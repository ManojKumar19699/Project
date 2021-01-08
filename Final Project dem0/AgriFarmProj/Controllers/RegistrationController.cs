using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;
using System.Web;

namespace AgriFarmProj.Controllers
{
    public class RegistrationController : ApiController
    {
        int fid;

        dbProjectEntities db = new dbProjectEntities();

        [HttpPost]
        [Route("Methodtwo")]
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
            //var filePath1 = HttpContext.Current.Server.MapPath("D:/Project_Angular/AgriFarmProj/src/assets/uploadeddocs/" + imageName1);
            postedFile1.SaveAs(filePath1);


            tblFarmer fmr = new tblFarmer();
            //Save to DB
            using (dbProjectEntities db = new dbProjectEntities())
            {
                #region saving data into db
                List<tblFarmer> farmers = db.tblFarmers.ToList();
                List<tblBank> banks = db.tblBanks.ToList();

                foreach (tblFarmer tblFarmer1 in farmers)
                {
                    if (tblFarmer1.FarmerEmail == httpRequest["FarmerEmail"]) return Ok("Email");
                }

                foreach (tblBank tblBank1 in banks)
                {
                    if (tblBank1.AccountNo == httpRequest["AccountNo"]) return Ok("Account");
                }
                try
                {
                    fmr.FarmerAadhar = imageName;
                    fmr.FarmerCertificate = imageName1;

                    fmr.FarmerName = httpRequest["FarmerName"];
                    fmr.FarmerContactNo = httpRequest["FarmerContactNo"];
                    fmr.FarmerAddress = httpRequest["FarmerAddress"];
                    fmr.FarmerCity = httpRequest["FarmerCity"];
                    fmr.FarmerState = httpRequest["FarmerState"];
                    fmr.FarmerPincocde = httpRequest["FarmerPincocde"];
                    fmr.FarmerEmail = httpRequest["FarmerEmail"];
                    fmr.FarmerPassword = httpRequest["FarmerPassword"];
                    fmr.FarmerApproved = false;
                    byte[] encData_byte = new byte[fmr.FarmerPassword.Length];
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(fmr.FarmerPassword);
                    string encodedpassword = Convert.ToBase64String(encData_byte);
                    fmr.FarmerPassword = encodedpassword;
                    db.tblFarmers.Add(fmr);
                    db.SaveChanges();


                    // db.SaveChanges();
                    /*
                                }*/
                    List<tblFarmer> res = db.tblFarmers.ToList();

                    foreach (tblFarmer item in res)
                    {
                        if (item.FarmerEmail == fmr.FarmerEmail)
                        {
                            fid = item.FarmerId;
                            break;
                        }
                    }

                    tblBank tb1 = new tblBank();

                    using (dbProjectEntities db1 = new dbProjectEntities())
                    {


                        tb1.FarmerId = fid;
                        tb1.AccountNo = httpRequest["AccountNo"];
                        tb1.IFSC_Code = httpRequest["IFSC_Code"];
                        tb1.BidderId = null;

                        db1.tblBanks.Add(tb1);
                        db1.SaveChanges();

                        // db.SaveChanges();

                    }

                    tblFarmLand tb2 = new tblFarmLand();

                    using (dbProjectEntities db1 = new dbProjectEntities())
                    {
                        tb2.FarmerId = fid;

                        tb2.FarmerLandArea = httpRequest["FarmerLandArea"];
                        tb2.FarmerLandAddress = httpRequest["FarmerLandAddress"];
                        tb2.FarmerLandPincode = httpRequest["FarmerLandPincode"];
                        db1.tblFarmLands.Add(tb2);
                        db1.SaveChanges();
                    }
                    #endregion
                }
                catch (Exception)
                {
                    return Ok("Error");
                }

            }
            return Ok("OK");
        }
    }
}

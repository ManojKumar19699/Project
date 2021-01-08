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
    public class CropController : ApiController
    {
        dbProjectEntities db = new dbProjectEntities();

        [Route("Request")]
        public HttpResponseMessage Get()
        {
            var cp = db.tblCropRequests.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, cp);
        }

        [HttpPost]
        [Route("List")]

        public void Listing([FromBody] tblCropRequest cropRequest)
        {
            cropRequest.SoilPhCertificate = cropRequest.SoilPhCertificate.Replace("/", "-");
            cropRequest.FarmerId = 100;
            cropRequest.CropApproved = false;
            db.tblCropRequests.Add(cropRequest);
            db.SaveChanges();
        }

        [HttpPost]
        [Route("CropRequest")]
        public HttpResponseMessage WayTwo()
        {
            string imageName = "";
            string Qty = "";
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            var postedFile = httpRequest.Files["Image"];
            //Create custom filename
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
            postedFile.SaveAs(filePath);

            //Save to DB
            using (dbProjectEntities db = new dbProjectEntities())
            {
                tblCropRequest cpr = new tblCropRequest();

                cpr.SoilPhCertificate = imageName;
                cpr.CropType = httpRequest["CropType"];
                cpr.CropName = httpRequest["CropName"];
                cpr.FertilizerType = httpRequest["FertilizerType"];
                Qty = (httpRequest["Quantity"]);
                //Quantity = 25
                cpr.Quantity = Convert.ToInt32(Qty);
                cpr.FarmerId = Convert.ToInt32(httpRequest["FarmerID"]);
                cpr.CropApproved = false;
                db.tblCropRequests.Add(cpr);
                db.SaveChanges();
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}

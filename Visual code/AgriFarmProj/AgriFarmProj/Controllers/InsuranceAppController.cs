using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.ViewModel;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class InsuranceAppController : ApiController
    {
        dbProjectEntities db = new dbProjectEntities();

        [Route("api/ApplyInsurance")]
        public IHttpActionResult PostInsuranceRegistration(InsuranceApp regfom)
        {
            tblInsurance tblInsurance = new tblInsurance();
            tblInsurance.Season = regfom.Season;
            tblInsurance.Area = regfom.Area;
            tblInsurance.FarmerId = Convert.ToInt32(regfom.FarmerId);
            tblInsurance.CompanyName = regfom.CompanyName;
            tblInsurance.SumInsured = regfom.SumAssured;
            tblInsurance.Year = regfom.Year;
            tblInsurance.DateOfInsurance = DateTime.Today;
            tblInsurance.Crop = regfom.CropName;
            db.tblInsurances.Add(tblInsurance);
            db.SaveChanges();
            return Ok("OK");
        }
    }
}

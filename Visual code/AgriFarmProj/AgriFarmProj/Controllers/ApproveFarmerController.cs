using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgriFarmProj.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace AgriFarmProj.Controllers
{
    public class ApproveFarmerController : ApiController
    {
        private dbProjectEntities db = new dbProjectEntities();

        // GET: api/ApproveFarmer
        [Route("api/GetUnapprovedFarmers")]
        public IEnumerable<tblFarmer> GettblFarmers()
        {
            List<tblFarmer> res = db.tblFarmers.ToList();

            List<tblFarmer> output = new List<tblFarmer>();
            foreach (tblFarmer item in res)
            {
                if (!(bool)item.FarmerApproved) output.Add(item);
            }
            return output.AsEnumerable();
        }
        
        [Route("api/ApproveFarmerAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int Id, int adminId)
        {
            tblFarmer tblFarmer = db.tblFarmers.Find(Id);
            tblFarmer.FarmerApproved = true;
            tblFarmer.ApprovalAdminId = adminId;
            db.Entry(tblFarmer).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }
    }
}

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
        public IHttpActionResult GettblFarmers()
        {
            List<tblFarmer> res = db.tblFarmers.ToList();

            List<tblFarmer> output = new List<tblFarmer>();
            foreach (tblFarmer item in res)
            {
                if (!(bool)item.FarmerApproved) output.Add(item);
            }
            return Ok(output);
        }
        #region scaffolded methods for testing
        // GET: api/ApproveFarmer/5
        [ResponseType(typeof(tblFarmer))]
        public IHttpActionResult GettblFarmer(int id)
        {
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            if (tblFarmer == null)
            {
                return NotFound();
            }

            return Ok(tblFarmer);
        }

        // PUT: api/ApproveFarmer/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblFarmer(int id, tblFarmer tblFarmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblFarmer.FarmerId)
            {
                return BadRequest();
            }

            db.Entry(tblFarmer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblFarmerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApproveFarmer
        [ResponseType(typeof(tblFarmer))]
        public IHttpActionResult PosttblFarmer(tblFarmer tblFarmer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblFarmers.Add(tblFarmer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblFarmer.FarmerId }, tblFarmer);
        }

        // DELETE: api/ApproveFarmer/5
        [ResponseType(typeof(tblFarmer))]
        public IHttpActionResult DeletetblFarmer(int id)
        {
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            if (tblFarmer == null)
            {
                return NotFound();
            }

            db.tblFarmers.Remove(tblFarmer);
            db.SaveChanges();

            return Ok(tblFarmer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblFarmerExists(int id)
        {
            return db.tblFarmers.Count(e => e.FarmerId == id) > 0;
        }
        #endregion

        [Route("api/ApproveFarmerAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int id, int adminid)
        {
            tblFarmer tblFarmer = db.tblFarmers.Find(id);
            tblFarmer.FarmerApproved = true;
            tblFarmer.ApprovalAdminId = adminid;
            db.Entry(tblFarmer).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }
    }
}

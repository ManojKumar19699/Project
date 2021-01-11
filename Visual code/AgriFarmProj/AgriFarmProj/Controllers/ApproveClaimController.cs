using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class ApproveClaimController : ApiController
    {
        private dbProjectEntities db = new dbProjectEntities();

        // GET: api/ApproveClaim
        [Route("api/GetUnapprovedClaims")]
        public IHttpActionResult GettblInsuranceClaims()
        {
            List<tblInsuranceClaim> res = db.tblInsuranceClaims.ToList();

            List<tblInsuranceClaim> output = new List<tblInsuranceClaim>();
            foreach (tblInsuranceClaim item in res)
            {
                if (item.ApprovalStatus == "Not Approved") output.Add(item);
            }
            return Ok(output);
        }

        #region scaffolded methods for testing
        // GET: api/ApproveClaim/5
        [ResponseType(typeof(tblInsuranceClaim))]
        public IHttpActionResult GettblInsuranceClaim(int id)
        {
            tblInsuranceClaim tblInsuranceClaim = db.tblInsuranceClaims.Find(id);
            if (tblInsuranceClaim == null)
            {
                return NotFound();
            }

            return Ok(tblInsuranceClaim);
        }

        // PUT: api/ApproveClaim/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblInsuranceClaim(int id, tblInsuranceClaim tblInsuranceClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblInsuranceClaim.CliamId)
            {
                return BadRequest();
            }

            db.Entry(tblInsuranceClaim).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblInsuranceClaimExists(id))
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

        // POST: api/ApproveClaim
        [ResponseType(typeof(tblInsuranceClaim))]
        public IHttpActionResult PosttblInsuranceClaim(tblInsuranceClaim tblInsuranceClaim)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblInsuranceClaims.Add(tblInsuranceClaim);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblInsuranceClaim.CliamId }, tblInsuranceClaim);
        }

        // DELETE: api/ApproveClaim/5
        [ResponseType(typeof(tblInsuranceClaim))]
        public IHttpActionResult DeletetblInsuranceClaim(int id)
        {
            tblInsuranceClaim tblInsuranceClaim = db.tblInsuranceClaims.Find(id);
            if (tblInsuranceClaim == null)
            {
                return NotFound();
            }

            db.tblInsuranceClaims.Remove(tblInsuranceClaim);
            db.SaveChanges();

            return Ok(tblInsuranceClaim);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblInsuranceClaimExists(int id)
        {
            return db.tblInsuranceClaims.Count(e => e.CliamId == id) > 0;
        }
        #endregion

        [Route("api/ApproveClaimAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int Id, int adminId)
        {
            tblInsuranceClaim tblInsuranceClaim = db.tblInsuranceClaims.Find(Id);
            tblInsuranceClaim.ApprovalStatus = "Approved";
            tblInsuranceClaim.ApprovalAdminId = adminId;
            db.Entry(tblInsuranceClaim).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }

    }
}
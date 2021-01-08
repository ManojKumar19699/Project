using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace AgriFarmProj.Controllers
{
    public class ApproveBidderController : ApiController
    {
        private dbProjectEntities db = new dbProjectEntities();

        // GET: api/ApproveBidder
        [Route("api/GetUnapprovedBidders")]
        public IHttpActionResult GettblBidders()
        {
            List<tblBidder> res = db.tblBidders.ToList();

            List<tblBidder> output = new List<tblBidder>();
            foreach (tblBidder item in res)
            {
                if (!(bool)item.BidderApproved) output.Add(item);
            }
            return Ok(output);
        }


        #region scaffolded methods for testing
        // GET: api/ApproveBidder/5
        [ResponseType(typeof(tblBidder))]
        public IHttpActionResult GettblBidder(int id)
        {
            tblBidder tblBidder = db.tblBidders.Find(id);
            if (tblBidder == null)
            {
                return NotFound();
            }

            return Ok(tblBidder);
        }

        // PUT: api/ApproveBidder/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBidder(int id, tblBidder tblBidder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBidder.BidderId)
            {
                return BadRequest();
            }

            db.Entry(tblBidder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBidderExists(id))
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

        // POST: api/ApproveBidder
        [ResponseType(typeof(tblBidder))]
        public IHttpActionResult PosttblBidder(tblBidder tblBidder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBidders.Add(tblBidder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblBidder.BidderId }, tblBidder);
        }

        // DELETE: api/ApproveBidder/5
        [ResponseType(typeof(tblBidder))]
        public IHttpActionResult DeletetblBidder(int id)
        {
            tblBidder tblBidder = db.tblBidders.Find(id);
            if (tblBidder == null)
            {
                return NotFound();
            }

            db.tblBidders.Remove(tblBidder);
            db.SaveChanges();

            return Ok(tblBidder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBidderExists(int id)
        {
            return db.tblBidders.Count(e => e.BidderId == id) > 0;
        }
        #endregion

        [Route("api/ApproveBidderAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int id, int adminid)
        {
            tblBidder tblBidder = db.tblBidders.Find(id);
            tblBidder.BidderApproved = true;
            tblBidder.ApprovalAdminId = adminid;
            db.Entry(tblBidder).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }
    }
}


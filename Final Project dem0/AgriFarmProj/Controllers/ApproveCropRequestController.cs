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
    public class ApproveCropRequestController : ApiController
    {
        private dbProjectEntities db = new dbProjectEntities();

        [Route("api/GetUnapprovedCrops")]
        // GET: api/ApproveCropRequest
        public IHttpActionResult GettblCropRequests()
        {
            List<tblCropRequest> res = db.tblCropRequests.ToList();

            List<tblCropRequest> output = new List<tblCropRequest>();
            foreach (tblCropRequest item in res)
            {
                if (!(bool)item.CropApproved) output.Add(item);
            }
            return Ok(output);
        }

        [Route("api/AllCrops")]
        // GET: api/ApproveCropRequest
        public IHttpActionResult GetAllCropRequests()
        {
            return Ok(db.tblCropRequests.ToList());
        }

        #region scaffolded methods for testing

        // GET: api/ApproveCropRequest/5
        [ResponseType(typeof(tblCropRequest))]
        public IHttpActionResult GettblCropRequest(int id)
        {
            tblCropRequest tblCropRequest = db.tblCropRequests.Find(id);
            if (tblCropRequest == null)
            {
                return NotFound();
            }

            return Ok(tblCropRequest);
        }

        // PUT: api/ApproveCropRequest/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblCropRequest(int id, tblCropRequest tblCropRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblCropRequest.RequestId)
            {
                return BadRequest();
            }

            db.Entry(tblCropRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblCropRequestExists(id))
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

        // POST: api/ApproveCropRequest
        [ResponseType(typeof(tblCropRequest))]
        public IHttpActionResult PosttblCropRequest(tblCropRequest tblCropRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblCropRequests.Add(tblCropRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblCropRequest.RequestId }, tblCropRequest);
        }

        // DELETE: api/ApproveCropRequest/5
        [ResponseType(typeof(tblCropRequest))]
        public IHttpActionResult DeletetblCropRequest(int id)
        {
            tblCropRequest tblCropRequest = db.tblCropRequests.Find(id);
            if (tblCropRequest == null)
            {
                return NotFound();
            }

            db.tblCropRequests.Remove(tblCropRequest);
            db.SaveChanges();

            return Ok(tblCropRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblCropRequestExists(int id)
        {
            return db.tblCropRequests.Count(e => e.RequestId == id) > 0;
        }
        #endregion

        [Route("api/ApproveCropAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int id, int adminid, int initprice)
        {

            tblCropRequest tblCropRequest = db.tblCropRequests.Find(id);
            tblCropRequest.CropApproved = true;
            tblCropRequest.ApprovalAdminId = adminid;
            db.Entry(tblCropRequest).State = EntityState.Modified;
            db.SaveChanges();
            tblBidding tblBidding = new tblBidding();
            tblBidding.RequestId = tblCropRequest.RequestId;
            tblBidding.InitialPrice = initprice;
            tblBidding.CurrentBidPrice = initprice;
            tblBidding.PreviousBidPrice = initprice;
            DateTime dateTime = DateTime.Now;
            tblBidding.BidCloseTime = dateTime.AddMinutes(15);
            db.tblBiddings.Add(tblBidding);
            db.SaveChanges();
            return Ok("OK");
        }
    }
}

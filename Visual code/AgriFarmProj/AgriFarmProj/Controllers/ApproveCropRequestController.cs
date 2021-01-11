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
        public IQueryable<tblCropRequest> GettblCropRequests()
        {
            List<tblCropRequest> res = db.tblCropRequests.ToList();

            List<tblCropRequest> output = new List<tblCropRequest>();
            foreach (tblCropRequest item in res)
            {
                if (!(bool)item.CropApproved) output.Add(item);
            }
            return output.AsQueryable();
        }
        [Route("api/DeleteCropAdmin/")]
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


        [Route("api/ApproveCropAdmin/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int Id, int adminId, int initprice)
        {

            tblCropRequest tblCropRequest = db.tblCropRequests.Find(Id);
            tblCropRequest.CropApproved = true;
            tblCropRequest.ApprovalAdminId = adminId;
            db.Entry(tblCropRequest).State = EntityState.Modified;
            db.SaveChanges();
            tblBidding tblBidding = new tblBidding();
            tblBidding.RequestId = tblCropRequest.RequestId;
            tblBidding.InitialPrice = initprice;
            tblBidding.CurrentBidPrice = initprice;
            tblBidding.PreviousBidPrice = initprice;
            DateTime dateTime = DateTime.Now;
            tblBidding.BidCloseTime = dateTime.AddMinutes(720);
            db.tblBiddings.Add(tblBidding);
            db.SaveChanges();
            return Ok("OK");
        }
    }
}

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
        public IQueryable<tblBidder> GettblBidders()
        {
            List<tblBidder> res = db.tblBidders.ToList();

            List<tblBidder> output = new List<tblBidder>();
            foreach (tblBidder item in res)
            {
                if (!(bool)item.BidderApproved) output.Add(item);
            }
            return output.AsQueryable();
        }

        [Route("api/ApproveBidderAdmin/")]
        [HttpPost]

        public IHttpActionResult Post([FromUri] int Id,int adminId)
        {
            tblBidder bidder = db.tblBidders.Find(Id);
            bidder.BidderApproved = true;
            bidder.ApprovalAdminId = adminId;
            db.Entry(bidder).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }

        //public IHttpActionResult Post([FromUri] int id, int adminid)
        //{
        //    tblBidder tblBidder = db.tblBidders.Find(id);
        //    tblBidder.BidderApproved = true;
        //    tblBidder.ApprovalAdminId = adminid;
        //    db.Entry(tblBidder).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return Ok("OK");
        //}

    }
}


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
using AgriFarmProj.Models.ViewModel;

namespace AgriFarmProj.Controllers
{
    public class BidderMarketplaceController : ApiController
    {
        private dbProjectEntities db = new dbProjectEntities();

        [Route("api/GetCurrentSales")]
        public IHttpActionResult GetSales()
        {
            List<tblBidding> res = db.tblBiddings.ToList();
            var cp = (from crps in db.tblCropRequests
                      join bd in db.tblBiddings on
                      crps.RequestId equals bd.RequestId
                      select new
                      {
                          bd.BiddingId,
                          crps.CropType,
                          crps.CropName,
                          crps.Quantity,
                          bd.InitialPrice,
                          bd.PreviousBidPrice,
                          bd.BidCloseTime,
                          bd.CurrentBidPrice,
                          bd.ApprovalAdminId
                      }).ToList();
            List<BiddingCrops> output = new List<BiddingCrops>();
            foreach (var item in cp)
            {
                DateTime t1 = (DateTime)item.BidCloseTime;
                if (t1.Date >= DateTime.Now.Date && t1.TimeOfDay > DateTime.Now.TimeOfDay && item.ApprovalAdminId == null)
                {
                    BiddingCrops bd = new BiddingCrops();
                    bd.Biddingid = (int)item.BiddingId;
                    bd.CropName = item.CropName;
                    bd.CropType = item.CropType;
                    bd.Quantity = (int)item.Quantity;
                    bd.InitalPrce = (int)item.InitialPrice;
                    bd.CurrentBidPrice = (int)item.CurrentBidPrice;
                    bd.PreviousBidPrice = (int)item.PreviousBidPrice;
                    bd.BidCloseTime = (DateTime)item.BidCloseTime;
                    output.Add(bd);
                }
            }
            return Ok(output);
        }

        #region scaffolded methods for testing
        // GET: api/BidderMarketplace
        public IQueryable<tblBidding> GettblBiddings()
        {
            return db.tblBiddings;
        }

        // GET: api/BidderMarketplace/5
        [ResponseType(typeof(tblBidding))]
        public IHttpActionResult GettblBidding(int id)
        {
            tblBidding tblBidding = db.tblBiddings.Find(id);
            if (tblBidding == null)
            {
                return NotFound();
            }

            return Ok(tblBidding);
        }

        // PUT: api/BidderMarketplace/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBidding(int id, tblBidding tblBidding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBidding.BiddingId)
            {
                return BadRequest();
            }

            db.Entry(tblBidding).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBiddingExists(id))
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

        // POST: api/BidderMarketplace
        [ResponseType(typeof(tblBidding))]
        public IHttpActionResult PosttblBidding(tblBidding tblBidding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBiddings.Add(tblBidding);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblBidding.BiddingId }, tblBidding);
        }

        // DELETE: api/BidderMarketplace/5
        [ResponseType(typeof(tblBidding))]
        public IHttpActionResult DeletetblBidding(int id)
        {
            tblBidding tblBidding = db.tblBiddings.Find(id);
            if (tblBidding == null)
            {
                return NotFound();
            }

            db.tblBiddings.Remove(tblBidding);
            db.SaveChanges();

            return Ok(tblBidding);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBiddingExists(int id)
        {
            return db.tblBiddings.Count(e => e.BiddingId == id) > 0;
        }

        #endregion

        [Route("api/GetCropById")]
        public IHttpActionResult GetCropById([FromUri] int id)
        {

            var cp = (from crps in db.tblCropRequests
                      join bd in db.tblBiddings on
                      crps.RequestId equals bd.RequestId
                      select new
                      {
                          bd.BiddingId,
                          crps.CropType,
                          crps.CropName,
                          crps.Quantity,
                          bd.InitialPrice,
                          bd.PreviousBidPrice,
                          bd.BidCloseTime,
                          bd.CurrentBidPrice
                      }).ToList();
            BiddingCrops output = new BiddingCrops();
            foreach (var item in cp)
            {
                if (item.BiddingId == id)
                {
                    output.Biddingid = (int)item.BiddingId;
                    output.CropName = item.CropName;
                    output.CropType = item.CropType;
                    output.Quantity = (int)item.Quantity;
                    output.InitalPrce = (int)item.InitialPrice;
                    output.CurrentBidPrice = (int)item.CurrentBidPrice;
                    output.PreviousBidPrice = (int)item.PreviousBidPrice;
                    output.BidCloseTime = (DateTime)item.BidCloseTime;
                }
            }
            return Ok(output);
        }

        [Route("api/PlaceBid/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int id, int bidderID, int latestbid)
        {
            tblBidding tblBidding = db.tblBiddings.Find(id);
            tblBidding.BidderId = bidderID;
            tblBidding.PreviousBidPrice = tblBidding.CurrentBidPrice;
            tblBidding.CurrentBidPrice = latestbid;
            db.Entry(tblBidding).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("OK");
        }


        [Route("api/GetUnapprovedBids")]
        public IHttpActionResult GetAuctionDetails()
        {
            // List<tblBidding> res = db.tblBiddings.ToList();
            var cp = (from crps in db.tblCropRequests
                      join bd in db.tblBiddings on crps.RequestId equals bd.RequestId
                      join fmr in db.tblFarmers on crps.FarmerId equals fmr.FarmerId
                      select new
                      {
                          bd.BiddingId,
                          bd.BidderId,
                          fmr.FarmerId,
                          crps.CropType,
                          crps.CropName,
                          bd.InitialPrice,
                          crps.Quantity,
                          bd.BidCloseTime,
                          bd.CurrentBidPrice,
                          bd.ApprovalAdminId
                      }).ToList();
            List<AuctionCropDetails> output = new List<AuctionCropDetails>();
            foreach (var item in cp)
            {
                DateTime t1 = (DateTime)item.BidCloseTime;
                //t1.Date>DateTime.Now.Date
                if (t1.Date < DateTime.Now.Date || t1.TimeOfDay < DateTime.Now.TimeOfDay)
                    if (item.ApprovalAdminId == null && item.BidderId != null)
                    {
                        AuctionCropDetails crop = new AuctionCropDetails();
                        crop.Biddingid = (int)item.BiddingId;
                        crop.Farmerid = (int)item.FarmerId;
                        crop.Bidderid = (int)item.BidderId;
                        crop.CropName = item.CropName;
                        crop.Quantity = (int)item.Quantity;
                        crop.InitalPrce = (int)item.InitialPrice;
                        crop.CurrentBidPrice = (int)item.CurrentBidPrice;
                        output.Add(crop);
                    }
            }
            return Ok(output);
        }

        [Route("api/ApproveAuctionAdmin/")]
        [HttpPost]
        public IHttpActionResult ApproveAuctionAdmin([FromUri] int id, int adminid)
        {
            tblBidding tblBidding = db.tblBiddings.Find(id);
            tblBidding.ApprovalAdminId = adminid;
            tblCropRequest tblCropRequest = db.tblCropRequests.Find(tblBidding.RequestId);
            tblFarmer tblFarmer = db.tblFarmers.Find(tblCropRequest.FarmerId);
            tblSale tblSale = new tblSale();
            tblSale.FarmerId = tblFarmer.FarmerId;
            tblSale.BidderId = tblBidding.BidderId;
            tblSale.Quantity = (int?)tblCropRequest.Quantity;
            tblSale.CropName = tblCropRequest.CropName;
            tblSale.MinSalePrice = tblBidding.InitialPrice;
            tblSale.TotalPrice = tblBidding.CurrentBidPrice;
            tblSale.SaleDate = DateTime.Now.Date;
            tblSale.ApprovalAdminId = adminid;
            db.Entry(tblBidding).State = EntityState.Modified;

            db.tblSales.Add(tblSale);
            db.SaveChanges();
            return Ok("OK");

        }

    }
}

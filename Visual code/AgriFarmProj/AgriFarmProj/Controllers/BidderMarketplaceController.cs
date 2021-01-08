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
        public dbProjectEntities db = new dbProjectEntities();

        [Route("api/GetCurrentSales")]
        public IQueryable GetSales()
        {
            List<sp_bidding_Result> res = db.sp_bidding().ToList();
            return res.AsQueryable();
            //var cp = (from crps in db.tblCropRequests
            //          join bd in db.tblBiddings on
            //          crps.RequestId equals bd.RequestId
            //          select new
            //          {
            //              bd.BiddingId,
            //              crps.CropType,
            //              crps.CropName,
            //              crps.Quantity,
            //              bd.InitialPrice,
            //              bd.PreviousBidPrice,
            //              bd.BidCloseTime,
            //              bd.CurrentBidPrice,
            //              bd.ApprovalAdminId
            //          }).ToList();
            //List<BiddingCrops> output = new List<BiddingCrops>();
            //foreach (var item in cp)
            //{
            //    DateTime t1 = (DateTime)item.BidCloseTime;
            //    if (t1.Date >= DateTime.Now.Date && t1.TimeOfDay > DateTime.Now.TimeOfDay && item.ApprovalAdminId == null)
            //    {
            //        BiddingCrops bd = new BiddingCrops();
            //        bd.BiddingId = (int)item.BiddingId;
            //        bd.CropName = item.CropName;
            //        bd.CropType = item.CropType;
            //        bd.Quantity = (int)item.Quantity;
            //        bd.InitialPrice = (int)item.InitialPrice;
            //        bd.CurrentBidPrice = (int)item.CurrentBidPrice;
            //        bd.PreviousBidPrice = (int)item.PreviousBidPrice;
            //        bd.BidCloseTime = (DateTime)item.BidCloseTime;
            //        output.Add(bd);
            //    }
            //}
            
        }


        [Route("api/GetCropById")]
        public IHttpActionResult GetCropById([FromUri] int Id)
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
                if (item.BiddingId == Id)
                {
                    output.BiddingId = (int)item.BiddingId;
                    output.CropName = item.CropName;
                    output.CropType = item.CropType;
                    output.Quantity = (int)item.Quantity;
                    output.InitialPrice = (int)item.InitialPrice;
                    output.CurrentBidPrice = (int)item.CurrentBidPrice;
                    output.PreviousBidPrice = (int)item.PreviousBidPrice;
                    output.BidCloseTime = (DateTime)item.BidCloseTime;
                }
            }
            return Ok(output);
        }

        [Route("api/PlaceBid/")]
        [HttpPost]
        public IHttpActionResult Post([FromUri] int Id, int bidderID, int latestbid)
        {
            tblBidding tblBidding = db.tblBiddings.Find(Id);
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
                        crop.BiddingId = (int)item.BiddingId;
                        crop.FarmerId = (int)item.FarmerId;
                        crop.BidderId = (int)item.BidderId;
                        crop.CropName = item.CropName;
                        crop.Quantity = (int)item.Quantity;
                        crop.InitialPrice = (int)item.InitialPrice;
                        crop.CurrentBidPrice = (int)item.CurrentBidPrice;
                        output.Add(crop);
                    }
            }
            return Ok(output);
        }

        [Route("api/ApproveAuctionAdmin/")]
        [HttpPost]
        public IHttpActionResult ApproveAuctionAdmin([FromUri] int Id, int adminId)
        {
            tblBidding tblBidding = db.tblBiddings.Find(Id);
            tblBidding.ApprovalAdminId = adminId;
            tblCropRequest tblCropRequest = db.tblCropRequests.Find(tblBidding.RequestId);
            tblFarmer tblFarmer = db.tblFarmers.Find(tblCropRequest.FarmerId);
            tblSale tblSale = new tblSale();
            tblSale.FarmerId = tblFarmer.FarmerId;
            tblSale.BidderId = tblBidding.BidderId;
            tblSale.Quantity = (int?)tblCropRequest.Quantity;
            tblSale.CropName = tblCropRequest.CropName;
            tblSale.MinSalePrice = tblBidding.InitialPrice;
            tblSale.TotalPrice = tblBidding.CurrentBidPrice;
            tblSale.SoldPrice = tblBidding.CurrentBidPrice;
            tblSale.SaleDate = DateTime.Now.Date;
            tblSale.ApprovalAdminId = adminId;
            db.Entry(tblBidding).State = EntityState.Modified;

            db.tblSales.Add(tblSale);
            db.SaveChanges();
            return Ok("OK");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;


namespace AgriFarmProj.Controllers
{
    public class FarmerMarketPlaceController : ApiController
    {

        dbProjectEntities db = new dbProjectEntities();

        [HttpGet]
        [Route("Farmerplace")]
        public HttpResponseMessage Get()
        {
            var cp = (from crps in db.tblCropRequests
                      join bd in db.tblBiddings on
                      crps.RequestId equals bd.RequestId
                      select new
                      {
                          crps.CropType,
                          crps.CropName,
                          crps.Quantity,
                          bd.InitialPrice,
                          bd.PreviousBidPrice,
                          bd.BidCloseTime,
                          bd.CurrentBidPrice
                      }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, cp);
        }
    }
}


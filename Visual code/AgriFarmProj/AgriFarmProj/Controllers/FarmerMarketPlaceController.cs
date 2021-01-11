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
        public IQueryable Get()
        {
            List<sp_farmermarket_Result> res = db.sp_farmermarket().ToList();
            return res.AsQueryable();
        }
    }
}



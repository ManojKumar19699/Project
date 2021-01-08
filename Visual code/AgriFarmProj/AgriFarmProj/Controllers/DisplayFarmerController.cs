using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgriFarmProj.Models;

namespace AgriFarmProj.Controllers
{
    public class DisplayFarmerController : ApiController
    {
        dbProjectEntities ac = new dbProjectEntities();
        
        public IEnumerable<tblBidder> GetBidder()
        {

            return ac.tblBidders.AsEnumerable();
        }
        

    }
}

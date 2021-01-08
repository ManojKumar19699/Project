using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
    public class AuctionCropDetails
    {
		public int Biddingid { get; set; }
		public int Bidderid { get; set; }
		public int Farmerid { get; set; }
		public string CropName { get; set; }
		public int InitalPrce { get; set; }
		public int CurrentBidPrice { get; set; }
		public int Quantity { get; set; }
	}
}
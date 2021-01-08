using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
	public class AuctionCropDetails
	{
		public int BiddingId { get; set; }
		public int BidderId { get; set; }
		public int FarmerId { get; set; }
		public string CropName { get; set; }
		public int InitialPrice { get; set; }
		public int CurrentBidPrice { get; set; }
		public int Quantity { get; set; }
	}
}
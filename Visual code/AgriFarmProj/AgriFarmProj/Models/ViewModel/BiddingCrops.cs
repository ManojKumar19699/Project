using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
	public class BiddingCrops
	{
		public int BiddingId { get; set; }
		public string CropType { get; set; }
		public string CropName { get; set; }
		public int Quantity { get; set; }
		public int InitialPrice { get; set; }
		public int PreviousBidPrice { get; set; }
		public int CurrentBidPrice { get; set; }
		public DateTime BidCloseTime { get; set; }
	}
}
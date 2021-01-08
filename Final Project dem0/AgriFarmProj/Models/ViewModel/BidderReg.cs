using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
    public class BidderReg
    {
        public string BidderName { get; set; }
        public string BidderEmail { get; set; }
        public string BidderContactNo { get; set; }
        public string BidderAddress { get; set; }
        public string BidderCity { get; set; }
        public string BidderState { get; set; }
        public string BidderPincocde { get; set; }
        public string BidderAadhar { get; set; }
        public string BidderTradeLicense { get; set; }
        public string BidderPassword { get; set; }

        public string AccountNo { get; set; }
        public string IFSC_Code { get; set; }
    }
}
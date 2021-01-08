using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriFarmProj.Models.ViewModel
{
    public class FarmerReg
    {
        public string FarmerName { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerContactNo { get; set; }
        public string FarmerAddress { get; set; }
        public string FarmerCity { get; set; }
        public string FarmerState { get; set; }
        public string FarmerPincocde { get; set; }
        public string FarmerAadhar { get; set; }
        public string FarmerCertificate { get; set; }
        public string FarmerPassword { get; set; }

        public string FarmerLandArea { get; set; }
        public string FarmerLandAddress { get; set; }
        public string FarmerLandPincode { get; set; }

        public string AccountNo { get; set; }
        public string IFSC_Code { get; set; }

    }
}
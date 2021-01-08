//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgriFarmProj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFarmer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblFarmer()
        {
            this.tblBanks = new HashSet<tblBank>();
            this.tblCropRequests = new HashSet<tblCropRequest>();
            this.tblFarmLands = new HashSet<tblFarmLand>();
            this.tblInsurances = new HashSet<tblInsurance>();
            this.tblSales = new HashSet<tblSale>();
        }
    
        public int FarmerId { get; set; }
        public string FarmerName { get; set; }
        public string FarmerContactNo { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerAddress { get; set; }
        public string FarmerCity { get; set; }
        public string FarmerState { get; set; }
        public string FarmerPincocde { get; set; }
        public string FarmerAadhar { get; set; }
        public string FarmerPAN { get; set; }
        public string FarmerCertificate { get; set; }
        public string FarmerPassword { get; set; }
        public Nullable<bool> FarmerApproved { get; set; }
        public Nullable<int> ApprovalAdminId { get; set; }
    
        public virtual tblAdmin tblAdmin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBank> tblBanks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCropRequest> tblCropRequests { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblFarmLand> tblFarmLands { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInsurance> tblInsurances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSale> tblSales { get; set; }
    }
}
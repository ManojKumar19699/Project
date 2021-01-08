
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
    
public partial class tblCropRequest
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tblCropRequest()
    {

        this.tblBiddings = new HashSet<tblBidding>();

    }


    public int RequestId { get; set; }

    public Nullable<int> FarmerId { get; set; }

    public string CropType { get; set; }

    public string CropName { get; set; }

    public string FertilizerType { get; set; }

    public Nullable<decimal> Quantity { get; set; }

    public string SoilPhCertificate { get; set; }

    public Nullable<bool> CropApproved { get; set; }

    public Nullable<int> ApprovalAdminId { get; set; }



    public virtual tblAdmin tblAdmin { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<tblBidding> tblBiddings { get; set; }

    public virtual tblFarmer tblFarmer { get; set; }

}

}

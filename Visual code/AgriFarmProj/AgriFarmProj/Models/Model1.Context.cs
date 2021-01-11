﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbProjectEntities : DbContext
    {
        public dbProjectEntities()
            : base("name=dbProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblBank> tblBanks { get; set; }
        public virtual DbSet<tblBidder> tblBidders { get; set; }
        public virtual DbSet<tblBidding> tblBiddings { get; set; }
        public virtual DbSet<tblContactU> tblContactUs { get; set; }
        public virtual DbSet<tblCropRequest> tblCropRequests { get; set; }
        public virtual DbSet<tblFarmer> tblFarmers { get; set; }
        public virtual DbSet<tblFarmLand> tblFarmLands { get; set; }
        public virtual DbSet<tblInsurance> tblInsurances { get; set; }
        public virtual DbSet<tblInsuranceClaim> tblInsuranceClaims { get; set; }
        public virtual DbSet<tblSale> tblSales { get; set; }
    
        public virtual ObjectResult<sp_bidding_Result> sp_bidding()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_bidding_Result>("sp_bidding");
        }
    
        public virtual ObjectResult<sp_saleshistory_Result> sp_saleshistory(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_saleshistory_Result>("sp_saleshistory", idParameter);
        }
    
        public virtual ObjectResult<sp_salehistoryfarmer_Result> sp_salehistoryfarmer(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_salehistoryfarmer_Result>("sp_salehistoryfarmer", idParameter);
        }
    
        public virtual ObjectResult<sp_farmermarket_Result> sp_farmermarket()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_farmermarket_Result>("sp_farmermarket");
        }
    
        public virtual ObjectResult<sp_approveauction_Result> sp_approveauction()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_approveauction_Result>("sp_approveauction");
        }
    }
}

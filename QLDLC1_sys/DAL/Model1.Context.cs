﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

    public partial class QLDLEntities : DbContext
    {
        public QLDLEntities()
            : base("name=QLDLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administrative_regions> administrative_regions { get; set; }
        public virtual DbSet<administrative_units> administrative_units { get; set; }
        public virtual DbSet<BillExport> BillExport { get; set; }
        public virtual DbSet<BillExportDetails> BillExportDetails { get; set; }
        public virtual DbSet<BillImport> BillImport { get; set; }
        public virtual DbSet<BillImportDetails> BillImportDetails { get; set; }
        public virtual DbSet<Bonus> Bonus { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<districts> districts { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<productgroup> productgroup { get; set; }
        public virtual DbSet<provinces> provinces { get; set; }
        public virtual DbSet<Receipts> Receipts { get; set; }
        public virtual DbSet<Recharge> Recharge { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<wards> wards { get; set; }
        public virtual DbSet<dailycap> dailycap { get; set; }
        public virtual DbSet<NhaSX> NhaSX { get; set; }
    }
}

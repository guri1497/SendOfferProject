﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Product.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WITSProjectEntities : DbContext
    {
        public WITSProjectEntities()
            : base("name=WITSProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblAddress> tblAddress { get; set; }
        public virtual DbSet<tblOfferPrice> tblOfferPrice { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<tblProduct> tblProduct { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Good_Luck
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class newCaspotatdb3Entities3 : DbContext
    {
        public newCaspotatdb3Entities3()
            : base("name=newCaspotatdb3Entities3")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adress> Adresses { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Donor> Donors { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Kind_Of_Contact> Kind_Of_Contact { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
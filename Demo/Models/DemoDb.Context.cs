﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Demo.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DemoDbEntities : DbContext
    {
        public DemoDbEntities()
            : base("name=DemoDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public System.Data.Entity.DbSet<Demo.Pocos.UserPocos> UserPocos { get; set; }

        public System.Data.Entity.DbSet<Demo.Pocos.DepartmentPocos> DepartmentPocos { get; set; }
    }
}

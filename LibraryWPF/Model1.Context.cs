﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryWPF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WPFLIBDATABASEEntities : DbContext
    {
        public WPFLIBDATABASEEntities()
            : base("name=WPFLIBDATABASEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<DisciplineModel> DisciplineModels { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }
        public virtual DbSet<StudentModelLogin> StudentModelLogins { get; set; }
        public virtual DbSet<View_DisciplinedMarks> View_DisciplinedMarks { get; set; }
        public virtual DbSet<View_TotalMarks> View_TotalMarks { get; set; }
    }
}

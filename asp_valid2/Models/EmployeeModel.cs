namespace asp_valid2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeModel : DbContext
    {
        public EmployeeModel()
            : base("name=EmployeeModel")
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Language> Language { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FamilyName)
                .IsFixedLength();

            modelBuilder.Entity<Language>()
                .Property(e => e.LanguageName)
                .IsFixedLength();
        }
    }
}

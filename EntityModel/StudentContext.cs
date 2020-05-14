namespace WpfStudentManagments.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
        }

        public virtual DbSet<Table_1> Table_1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table_1>()
                .Property(e => e.StudentName)
                .IsUnicode(false);

            modelBuilder.Entity<Table_1>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<Table_1>()
                .Property(e => e.Subject)
                .IsUnicode(false);

            modelBuilder.Entity<Table_1>()
                .Property(e => e.FatherName)
                .IsUnicode(false);

            modelBuilder.Entity<Table_1>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}

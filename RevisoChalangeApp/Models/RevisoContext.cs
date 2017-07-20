namespace RevisoChalangeApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RevisoContext : DbContext
    {
        public RevisoContext()
            : base("name=RevisoContext")
        {
        }

        public virtual DbSet<Activeproject> Activeprojects { get; set; }
        public virtual DbSet<Workinghour> Workinghours { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activeproject>()
                .Property(e => e.PName)
                .IsUnicode(false);

            modelBuilder.Entity<Activeproject>()
                .Property(e => e.AuthorName)
                .IsUnicode(false);

            modelBuilder.Entity<Activeproject>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Activeproject>()
                .HasMany(e => e.Workinghours)
                .WithRequired(e => e.Activeproject)
                .HasForeignKey(e => e.PId)
                .WillCascadeOnDelete(false);
        }
    }
}

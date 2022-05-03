using Microsoft.EntityFrameworkCore;
using AaronSite.Models;

namespace AaronSite.Data
{
    public class Db : DbContext
    {
        public Db (DbContextOptions<Db> options) : base(options)
        {
        }
         
        public DbSet<Page> Pages { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<ClimbGrade> ClimbGrades { get; set; }
        public DbSet<ClimbEntry> ClimbEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Page>().ToTable("Pages");
            modelBuilder.Entity<Template>().ToTable("Templates");
            modelBuilder.Entity<ClimbGrade>().ToTable("ClimbGrades");
            modelBuilder.Entity<ClimbEntry>().ToTable("ClimbEntries");
        }
    }
}

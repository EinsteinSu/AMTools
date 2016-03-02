using System.Data.Entity;
using System.Data.Entity.Migrations;
using CaseProcesser.Models;

namespace CaseProcesser.Common
{
    public class CaseContext : DbContext
    {
        public CaseContext()
            : base("Name=CaseDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Case>().Ignore(p => p.IsNotifying);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Case> Cases { get; set; }
    }
}
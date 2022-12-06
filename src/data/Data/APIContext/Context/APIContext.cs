using data.Data.APIContext.Configurations;
using data.Data.APIContext.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace data.Data.APIContext.Context
{
    public partial class APIContext : IdentityDbContext<User, Role, Guid>
    {
        public APIContext()
        {
        }

        public APIContext(DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }

        #region DbQuery
        // En esta region se pueden crear DbSet virtuales de consultas, por ejemplo para realizar un FromSql
        //public virtual DbSet<AnalysisListQuery> AnalysisListQuery { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            //modelBuilder.Entity<AnalysisListQuery>().HasNoKey();
        }
    }
}

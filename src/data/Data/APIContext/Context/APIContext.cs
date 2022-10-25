using data.Data.APIContext.Configurations;
using data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;

namespace data.Data.APIContext.Context
{
    public partial class APIContext : DbContext
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
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "db_owner");
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            //modelBuilder.Entity<AnalysisListQuery>().HasNoKey();
        }
    }
}

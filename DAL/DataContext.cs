using DAL.DbModels;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DbSet<DbItem> Items { get; set; }
        public DbSet<DbOrderLine> OrderLines { get; set; }
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbPostAddress> PostAddresses { get; set; }
        public DbSet<DbReceipt> Receipts { get; set; }
        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbRole> Roles { get; set; }
        public DbSet<DbItemCategory> Category { get; set; }

        public DataContext() : base("name=DataContext")
        {
            Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}

using DAL.DbModels;
using DAL.Utilities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

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
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }

        public override int SaveChanges()
        {
            var addedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditedEntity>()
              .Where(p => p.State == EntityState.Modified)
              .Select(p => p.Entity);

            var now = DateTime.UtcNow;

            foreach (var added in addedAuditedEntities)
            {
                added.CreatedAt = now;
                added.LastModifiedAt = now;
                
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                modified.LastModifiedAt = now;
                
            }
            try
            {
                return base.SaveChanges();
            }
            catch(Exception e)
            {
                
                //e.logToFile(SEVERITY.ERROR, DateTime.Now, e.Message);
            }
            return 0;
        }

        


    }
}

using DAL.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataServices
{
    public class DataContext : DbContext
    {
        public DbSet<DbItem> Items {get; set; }
        public DbSet<DbOrderLine> OrderLines { get; set; }
        public DbSet<DbOrder> Orders { get; set; }
        public DbSet<DbPostAddress> PostAddresses { get; set; }
        public DbSet<DbReceipt> Receipts { get; set; }
        public DbSet<DbCustomer> Customer { get; set; }

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

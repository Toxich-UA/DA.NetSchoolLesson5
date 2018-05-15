using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson4.Entity;
using Lesson4.Model;

namespace BankModel.Mappinds
{
    public class BankDbContext : DbContext, IBankContext
    {
        

        public BankDbContext() : base("Name=LocalBankDb")
        {
        }
        static BankDbContext()
        {
            Database.SetInitializer<BankDbContext>(new CreateDatabaseIfNotExists<BankDbContext>());
        }
        
        public IDbSet<Clients> Clients { get; set; }
        public IDbSet<Cards> Cards { get; set; }
        public IDbSet<Addresses> Addresseses { get; set; }
        public IDbSet<Operations> Operations { get; set; }

        public int Save()
        {
            return SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CardConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new OperationConfiguration());
            modelBuilder.Configurations.Add(new AddressesConfiguration());

        }
    }
}

using Domain.Entieties;
using System.Data.Entity;


namespace Domain.DatabaseContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("AppDB")
        {
            //Database.SetInitializer<ApplicationContext>(new CreateDatabaseIfNotExists<ApplicationContext>());
            //Database.SetInitializer<ApplicationContext>(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
            Database.SetInitializer<ApplicationContext>(new MigrateDatabaseToLatestVersion<ApplicationContext, Domain.Migrations.Configuration>("AppDB"));
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("CustomerInfo");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
  public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("Context")
        {
       //     Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationContext, Configuration>());
            Database.CommandTimeout = 0;
            //  this.Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<decimal>().Configure(config => config.HasPrecision(18, 3));
        }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Utilisateur> Utilisateurs { get; set; }

        public DbSet<Employeur> Employeurs { get; set; }
    }
}

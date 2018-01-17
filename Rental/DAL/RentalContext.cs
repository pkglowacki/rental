using Rental.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Rental.DAL
{
    public class RentalContext : DbContext
    {
        public RentalContext() : base("SportRental")
        { }

        public DbSet<Urządzenie> Urządzenia { get; set; }
        public DbSet<Zamówienie> Zamówienia { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
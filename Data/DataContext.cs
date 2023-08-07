using CarReview.Models;
using Microsoft.EntityFrameworkCore;

namespace CarReview.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AwardProvider> AwardProviders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCategory>()
                .HasKey(cc => new { cc.CarId, cc.CategoryId });
            modelBuilder.Entity<CarCategory>()
                .HasOne(c => c.Car)
                .WithMany(cc => cc.CarCategories)
                .HasForeignKey(c => c.CarId);
            modelBuilder.Entity<CarCategory>()
                .HasOne(c => c.Category)
                .WithMany(cc => cc.CarCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<CarOwner>()
                .HasKey(co => new { co.CarId, co.OwnerId });
            modelBuilder.Entity<CarOwner>()
                .HasOne(c => c.Car)
                .WithMany(co => co.CarOwners)
                .HasForeignKey(c => c.CarId);
            modelBuilder.Entity<CarOwner>()
                .HasOne(c => c.Owner)
                .WithMany(cc => cc.CarOwners)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}

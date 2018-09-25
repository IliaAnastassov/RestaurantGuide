using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RestaurantGuide.Entities;

namespace RestaurantGuide.DataAccess
{
    class RestaurantGuideDb : DbContext
    {
        public RestaurantGuideDb() : base("DefaultConnection")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantReview> RestaurantReviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

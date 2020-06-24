using Data.MenuInfo;
using Data.RestaurantInfo;
using Data.UserInfo;
using DataAccess.Properties;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    class RestaurantContext : IdentityDbContext
    {
        public RestaurantContext() : base()
        {

        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Resources.ConnectionString);

            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>().HasOne(x => x.JadeUser).WithOne(x => x.Person);
            base.OnModelCreating(builder);

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<DietaryRestriction> DietaryRestrictions { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Serving> MenuDishCourses { get; set; }
        public DbSet<Serving> Servings { get; set; }
        public DbSet<ClientRecord> ClientRecords { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<StaffRecord> StaffRecords { get; set; }
        public DbSet<StaffTitle> StaffTitles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }

}

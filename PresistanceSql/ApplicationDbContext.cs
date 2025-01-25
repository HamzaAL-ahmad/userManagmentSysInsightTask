namespace PresistanceSql
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Model;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.UserInfo)
                .WithOne(ui => ui.ApplicationUser)
                .HasForeignKey<UserInfo>(ui => ui.ID_User);


            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(co => co.Cities)
                .HasForeignKey(c => c.ID_Country);


            modelBuilder.Entity<UserInfo>()
                .HasOne(ui => ui.City)
                .WithMany(c => c.UserInfos)
                .HasForeignKey(ui => ui.ID_City);

            modelBuilder.Entity<Country>().HasData(
                  new Country { ID = 1, Name = "USA" },
                  new Country { ID = 2, Name = "Jordan" },
                  new Country { ID = 3, Name = "UK" }
                    );


            modelBuilder.Entity<City>().HasData(
                new City { ID = 1, Name = "New York", ID_Country = 1 },
                new City { ID = 2, Name = "Amman", ID_Country = 2 },
                new City { ID = 3, Name = "London", ID_Country = 3 }
            );
        }

    }
}

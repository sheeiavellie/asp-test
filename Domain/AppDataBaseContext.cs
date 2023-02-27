using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain
{
    public class AppDataBaseContext : IdentityDbContext<IdentityUser>
    {
        public AppDataBaseContext() { }
        public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options) : base(options) { }

        public DbSet<Offer.Offer> OffersBase { get; set; }
        public DbSet<Offer.UniqueOfferProperties> OffersCustomProperties { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*builder.Entity<Offer.Offer>()
                .ToTable("OffersBase")
                .HasKey(e => e.ID);

            builder.Entity<Offer.UniqueOfferProperties>()
                .ToTable("OffersCustomProperties")
                .HasKey(e => e.ID);*/

            /*builder.Entity<Offer.Offer>().HasData(new Offer.Offer
            {
                ID = 1,
                categoryID = 1,
                description = "initial"
            });*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var connectionString = configuration.GetConnectionString("offersDB");

            optionsBuilder.UseSqlServer(connectionString);*/
        }
    }
}

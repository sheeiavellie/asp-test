using AspTest.Domain.Offer;
using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain.Repositories
{
    public class UniqueOffersPropertiesRepository : IRepository<UniqueOfferProperties>
    {
        private readonly AppDataBaseContext context;

        public UniqueOffersPropertiesRepository(AppDataBaseContext context)
        {
            this.context = context;
        }

        public void Delete(UniqueOfferProperties property)
        {
            context.OffersCustomProperties.Remove(property);
        }

        public IQueryable<UniqueOfferProperties> GetAll()
        {
            return context.OffersCustomProperties.OrderBy(x => x.ID);
        }

        public UniqueOfferProperties GetById(int id)
        {
            return context.OffersCustomProperties.FirstOrDefault(x => x.ID == id);
        }

        public void Insert(UniqueOfferProperties property)
        {
            if (context.OffersCustomProperties.Single(x => x.ID == property.ID) == null)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    Console.WriteLine("Inserting offer to OfferBase");
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OffersCustomProperties ON");
                    context.OffersCustomProperties.Add(property);
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OffersCustomProperties OFF");

                    transaction.Commit();
                }
            }
        }
    }
}

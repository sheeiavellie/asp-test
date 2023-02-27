using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain.Repositories
{
    public class OffersRepository : IOffersRepository
    {
        private readonly AppDataBaseContext context;

        public OffersRepository(AppDataBaseContext context)
        {
            this.context = context;
        }

        public Offer.Offer GetOfferById(int id)
        {
            return context.OffersBase.FirstOrDefault(x => x.ID == id);
        }

        public void Delete(Offer.Offer offer)
        {
            context.OffersBase.Remove(offer);
        }

        public void DeleteById(int id)
        {
            context.OffersBase.Remove(context.OffersBase.Single(x => x.ID == id));
        }
        [HttpPost]
        public void Insert(Offer.Offer offer)
        {
            using(var transaction = context.Database.BeginTransaction())
            {
                Console.WriteLine("Inserting offer to OfferBase");
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OffersBase ON");
                context.OffersBase.Add(offer);
                context.SaveChanges();
                context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.OffersBase OFF");

                transaction.Commit();
            }            
        }

        public IQueryable<Offer.Offer> GetAll()
        {
            return context.OffersBase.OrderBy(x => x.ID);
        }
    }
}

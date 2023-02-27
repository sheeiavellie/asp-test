using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain.Repositories
{
    public class OffersRepository : IRepository<Offer.Offer>
    {
        private readonly AppDataBaseContext context;

        public OffersRepository(AppDataBaseContext context)
        {
            this.context = context;
        }

        public Offer.Offer GetById(int id)
        {
            return context.OffersBase.FirstOrDefault(x => x.ID == id);
        }

        public void Delete(Offer.Offer offer)
        {
            context.OffersBase.Remove(offer);
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

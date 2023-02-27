using Microsoft.EntityFrameworkCore;

namespace AspTest.Domain.Repositories
{
    public interface IOffersRepository
    {
        public Offer.Offer GetOfferById(int id);
        public IQueryable<Offer.Offer> GetAll();
        public void Delete(Offer.Offer offer);
        public void DeleteById(int id);
        public void Insert(Offer.Offer offer);
    }
}

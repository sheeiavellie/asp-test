using AspTest.Models.Offer;

namespace AspTest.Services
{
    public interface IOfferDataService
    {
        public OfferModel GetOfferById(int id);
        public void SaveOffer(OfferModel offer);
    }
}

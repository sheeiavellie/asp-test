using AspTest.Domain.Offer;
using AspTest.Domain.Repositories;
using AspTest.Models.Offer;
using AspTest.Utilities.Converters.DtoToModelConverter;

namespace AspTest.Services
{
    public class OfferDataService : IOfferDataService
    {
        private readonly IRepository<Offer> _offersRepository;
        private readonly IRepository<UniqueOfferProperties> _offersPropertiesRepository;
        private readonly IDtoToModelConverter<OfferDto, OfferModel> _dtoToModelConverter;
        public OfferDataService(
            IRepository<Offer> offersRepository, 
            IRepository<UniqueOfferProperties> offersPropertiesRepository,
            IDtoToModelConverter<OfferDto, OfferModel> dtoToModelConverter
        )
        {
            _offersRepository = offersRepository;
            _offersPropertiesRepository = offersPropertiesRepository;
            _dtoToModelConverter = dtoToModelConverter;
        }

        public OfferModel GetOfferById(int id)
        {
            var _offer = _offersRepository.GetById(id);
            var _properties = _offersPropertiesRepository
                .GetAll()
                .Where(x => x.offerID == _offer.ID)
                .ToList();
            return _dtoToModelConverter.Convert(new OfferDto
            {
                offer = _offer,
                properties = _properties
            });

            return null;
        }

        public void SaveOffer(OfferModel offer)
        {
            
        }
    }
}

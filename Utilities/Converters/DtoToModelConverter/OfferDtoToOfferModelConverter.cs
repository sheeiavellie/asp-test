using AspTest.Domain.Offer;
using AspTest.Models.Offer;

namespace AspTest.Utilities.Converters.DtoToModelConverter
{
    public class OfferDtoToOfferModelConverter : IDtoToModelConverter<OfferDto, OfferModel>
    {
        public OfferDto ConverBack(OfferModel model) //следовало бы написать отдельный конвертер
        {
            var counter = 0;

            return new OfferDto
            {
                offer = new Offer
                {
                    ID = model.ID,
                    categoryID = model.categoryID,
                    description = model.description,
                    url = model.url,
                    price = model.price,
                    currencyID = model.currencyID,
                    picture = model.picture
                },
                properties = model.categoryProperties
                    .Select(p => new UniqueOfferProperties {
                        //т.к. категорий мало, то в силу удобства можно записывать id так.
                        //Но это не верный способ и не рабочий способ на большом масштабе
                        ID = model.ID * 1000 + ++counter, 
                        categoryID = model.categoryID,
                        offerID = model.ID,
                        propertyName = p.Key,
                        propertyValue = p.Value
                    })
                    .ToList()
            };
        }

        public OfferModel Convert(OfferDto offerdto)
        {
            return new OfferModel
            {
                ID = offerdto.offer.ID,
                categoryID = offerdto.offer.categoryID,
                description = offerdto.offer.description,
                url = offerdto.offer.url,
                price = offerdto.offer.price,
                currencyID = offerdto.offer.currencyID,
                picture = offerdto.offer.picture,
                categoryProperties = offerdto.properties.ToDictionary(key => key.propertyName, value => value.propertyValue)
            };
        }
    }
}

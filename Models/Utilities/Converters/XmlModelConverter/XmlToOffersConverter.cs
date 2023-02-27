using AspTest.Models.Utilities.Converters.StringModelConverter;
using System.Xml;

namespace AspTest.Models.Utilities.Converters.XmlModelConverter
{
    //probaly not good to name like that converter that works only with yml_catalog
    public class XmlToOffersConverter : IXmlModelConverter<List<Offer.OfferModel>> 
    {
        public List<Offer.OfferModel> Convert(XmlDocument xmlDocument)
        {
            List<Offer.OfferModel> Offers = new List<Offer.OfferModel>();

            XmlElement? xRoot = xmlDocument.DocumentElement;

            if (xRoot != null)
            {
                foreach (XmlNode node in xRoot.ChildNodes.Item(0).ChildNodes.Item(6).ChildNodes)
                {
                    var currentOffer = new Offer.OfferModel();

                    currentOffer.ID = System.Convert.ToInt32(node.Attributes.GetNamedItem("id").Value);

                    foreach (XmlNode property in node.ChildNodes)
                    {
                        switch (property.Name)
                        {
                            case "categoryId":
                                currentOffer.categoryID = System.Convert.ToInt32(property.InnerText);
                                break;

                            case "url":
                                currentOffer.url = property.InnerText;
                                break;

                            case "price":
                                currentOffer.price = System.Convert.ToDouble(property.InnerText);
                                break;

                            case "currencyId":
                                currentOffer.currencyID = property.InnerText;
                                break;

                            case "picture":
                                currentOffer.picture = property.InnerText;
                                break;

                            case "description":
                                currentOffer.description = property.InnerText;
                                break;

                            default:
                                try
                                {
                                    currentOffer.categoryProperties.Add(property.Name, property.InnerText);

                                } catch(ArgumentException argumentException)
                                {
                                    currentOffer.categoryProperties.Add(property.Name + "2", property.InnerText); //mb there is a better way to deal with that
                                }
                                
                                break;
                        }
                    }
                    Offers.Add(currentOffer);
                }
            }
            return Offers;
        }
    }
}

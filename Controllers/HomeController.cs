using AspTest.Domain.Repositories;
using AspTest.Models;
using AspTest.Models.Offer;
using AspTest.Models.Utilities.Converters.StringModelConverter;
using AspTest.Models.Utilities.Converters.XmlModelConverter;
using AspTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml;

namespace AspTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IXmlToModelConverter<List<Models.Offer.OfferModel>> _xmlConverter;
        private readonly IOfferDataService _offerDataService;

        private List<OfferModel> _offers;

        public HomeController(
            ILogger<HomeController> logger,
            IXmlToModelConverter<List<Models.Offer.OfferModel>> xmlConverter,
            IOfferDataService offerDataService
        )
        {
            _logger = logger;
            _xmlConverter = xmlConverter;
            _offerDataService = offerDataService;

            _offers = _xmlConverter.Convert(GetXml().Result);
            _offerDataService.SaveOffer(_offers.Single(x => x.ID == 12344));
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<XmlDocument> GetXml()
        {
            string url = "https://yastatic.net/market-export/_/partner/help/YML.xml";

            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var content = await response.Content.ReadAsByteArrayAsync();

                var xmlString = CodePagesEncodingProvider.Instance.GetEncoding(1251).GetString(content);

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);

                return xmlDoc;
            }     
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
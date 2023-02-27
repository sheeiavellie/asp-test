using AspTest.Domain.Repositories;
using AspTest.Models;
using AspTest.Models.Offer;
using AspTest.Models.Utilities.Converters.StringModelConverter;
using AspTest.Models.Utilities.Converters.XmlModelConverter;
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

        public HomeController(
            ILogger<HomeController> logger,
            IXmlToModelConverter<List<Models.Offer.OfferModel>> xmlConverter
        )
        {
            _logger = logger;
            _xmlConverter = xmlConverter;
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
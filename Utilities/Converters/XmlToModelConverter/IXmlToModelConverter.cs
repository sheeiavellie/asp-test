using System.Xml;

namespace AspTest.Models.Utilities.Converters.StringModelConverter
{
    public interface IXmlToModelConverter<T> 
        where T : class
    {
        public T Convert(XmlDocument xmlDocument);
    }
}

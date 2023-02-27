using System.Xml;

namespace AspTest.Models.Utilities.Converters.StringModelConverter
{
    public interface IXmlModelConverter<T> 
        where T : class
    {
        public T Convert(XmlDocument xmlDocument);
    }
}

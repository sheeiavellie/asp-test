using System.ComponentModel.DataAnnotations;

namespace AspTest.Domain.Offer
{
    public class UniqueOfferProperties
    {
        [Key]
        public int ID { get; set; }
        public int categoryID { get; set; }

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
    }
}

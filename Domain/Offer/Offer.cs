using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspTest.Domain.Offer
{
    public class Offer
    {
        [Key]
        public int ID { get; set; }
        public int categoryID { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public double price { get; set; }
        public string currencyID { get; set; }
        public string picture { get; set; }


    }
}

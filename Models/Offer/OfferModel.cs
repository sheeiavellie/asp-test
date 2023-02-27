namespace AspTest.Models.Offer
{
    public class OfferModel
    {
        public int ID;
        public int categoryID;
        public string? url;
        public double price;
        public string? currencyID;
        public string? picture;
        public string? description;

        public Dictionary<string, string>? categoryProperties = new Dictionary<string, string>();
    }
}

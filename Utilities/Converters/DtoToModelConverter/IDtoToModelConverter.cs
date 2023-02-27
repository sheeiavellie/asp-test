namespace AspTest.Utilities.Converters.DtoToModelConverter
{
    public interface IDtoToModelConverter<Dto, Model>
    {
        public Model Convert(Dto value);
        public Dto ConverBack(Model model);
    }
}

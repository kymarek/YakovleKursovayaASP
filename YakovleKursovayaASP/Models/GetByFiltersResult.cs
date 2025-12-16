namespace YakovleKursovayaASP.Models
{
    public class GetByFiltersResult
    {
        public List<Product> FilteredProducts { get; set; }
        public List<string> FieldsWithNonNullValues { get; set; }
    }
}

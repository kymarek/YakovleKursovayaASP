namespace YakovleKursovayaASP.Models
{
    public class Base
    {
        public long Id { get; set; }
        public decimal? Weight { get; set; }
        public string Size { get; set; }
        public string Brand { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductType ProductType { get; set; }
    }
}

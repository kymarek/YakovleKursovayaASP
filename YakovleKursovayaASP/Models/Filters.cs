namespace YakovleKursovayaASP.Models
{
    public class Filters
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Genre { get; set; }
        public string Thematics { get; set; }
        public string GameType { get; set; }
        public string StudingType { get; set; }
        public int? ProductTypes { get; set; }
        public int? WeightFrom { get; set; }
        public int? WeightTo { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int? PagesFrom { get; set; }
        public int? PagesTo { get; set; }
        public int? ClassFrom { get; set; }
        public int? ClassTo { get; set; }
        public int? PlayersFrom { get; set; }
        public int? PlayersTo { get; set; }
        public string BindingType { get; set; }
        public string Series { get; set; }
        public string Subject { get; set; }
        public string Sort { get; set; }
        public bool SortWay { get; set; }
    }
}

namespace YakovleKursovayaASP.Models
{
    public class ArtisticBook : Base
    {
        public string Thematics { get; set; }
        public string Genre { get; set; }
        public string Series { get; set; }
        public int Pages { get; set; }
        public string BindingType { get; set; }
    }
}

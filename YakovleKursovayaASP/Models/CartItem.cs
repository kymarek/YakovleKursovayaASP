namespace YakovleKursovayaASP.Models
{
    public class CartItem
    {
        public Base Product { get; set; }
        public int Count { get; set; }
        public decimal Summ { get; set; }
    }
}

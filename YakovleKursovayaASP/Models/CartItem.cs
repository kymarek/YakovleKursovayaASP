namespace YakovleKursovayaASP.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal Summ { get; set; }
    }
}

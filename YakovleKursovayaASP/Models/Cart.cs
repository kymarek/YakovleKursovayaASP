namespace YakovleKursovayaASP.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public decimal Summ { get; set; }
        public int Count { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            Summ = 0;
            Count = 0;
        }
    }
}

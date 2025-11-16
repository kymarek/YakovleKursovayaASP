namespace YakovleKursovayaASP.Models
{
    public class BoardGame : Base
    {
        public string Thematics { get; set; }
        public string Genre { get; set; }
        public DateTime GameTime { get; set; }
        public string GameType { get; set; }
        public int PlayersCount { get; set; }
    }
}

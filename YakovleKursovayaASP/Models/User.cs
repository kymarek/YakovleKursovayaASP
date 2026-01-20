namespace YakovleKursovayaASP.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    }
}

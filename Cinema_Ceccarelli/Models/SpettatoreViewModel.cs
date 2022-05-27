namespace Cinema_Ceccarelli.Models
{
    public class SpettatoreViewModel
    {
        public int IDSpett { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public bool Minore14 { get; set; }
        public DateTime DataNascita { get; set; }
        public int CodBiglietto { get; set; }
    }
}

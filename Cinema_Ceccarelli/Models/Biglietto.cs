namespace Cinema_Ceccarelli.Models
{
    public class Biglietto
    {
        public int IDBiglietto { get; set; }
        public int Posto { get; set; }
        public decimal Prezzo { get; set; }
        public int CodSala { get; set; }
        public int CodFilm { get; set; }
    }
}

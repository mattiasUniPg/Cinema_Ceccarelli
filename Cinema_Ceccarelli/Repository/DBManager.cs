using Cinema_Ceccarelli.Models;
using System.Data.SqlClient;

namespace Cinema_Ceccarelli.Repository
{
    public class DBManager
    {

        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = CINEMA; Trusted_Connection = True;";
        public List<FilmViewModel> GetAllFilm()
        {
            List<FilmViewModel> filmList = new List<FilmViewModel>();
            string sql = @"SELECT * 
                        FROM Film";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var film = new FilmViewModel
                {
                    IDFilm = Convert.ToInt32(reader["IDFilm"]),
                    Titolo = reader["Titolo"].ToString(),
                    Autore = reader["Autore"].ToString(),
                    Produttore = reader["Produttore"].ToString(),
                    Genere = reader["Genere"].ToString(),
                    Durata = Convert.ToInt32(reader["Durata"])
                };
                filmList.Add(film);
            }
            return filmList;
        }

        public int AggiungiFilm(FilmViewModel film)
        {
            string sql = @"INSERT INTO Film
            ([Titolo]
           ,[Autore]
           ,[Produttore]
           ,[Genere]
           ,[Durata])
            VALUES(@Titolo, @Autore, @Produttore, @Genere, @Durata); ";

            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Titolo", film.Titolo);
            command.Parameters.AddWithValue("@Autore", film.Autore);
            command.Parameters.AddWithValue("@Produttore", film.Produttore);
            command.Parameters.AddWithValue("@Genere", film.Genere);
            command.Parameters.AddWithValue("@Durata", film.Durata);

            return command.ExecuteNonQuery();
        }
   
        public int AggiungiBiglietto(BigliettoViewModel biglietto)
        {
            string sql = @"INSERT INTO Biglietto
            ([Posto]
           ,[Prezzo]
           ,[CodSala]
           ,[CodFilm])
           
           VALUES (@Posto,@Prezzo,@CodSala,@CodFilm) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Posto", biglietto.Posto);
            command.Parameters.AddWithValue("@Prezzo", biglietto.Prezzo);
            command.Parameters.AddWithValue("@CodSala", biglietto.CodSala);
            command.Parameters.AddWithValue("@CodFilm", biglietto.CodFilm);

            return command.ExecuteNonQuery();
        }   

    }

}

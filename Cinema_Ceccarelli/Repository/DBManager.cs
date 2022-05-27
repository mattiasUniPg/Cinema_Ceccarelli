using Cinema_Ceccarelli.Models;
using System.Data.SqlClient;

namespace Cinema_Ceccarelli.Repository
{
    public class DBManager
    {

        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = MUSIC; Trusted_Connection = True;";


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
                    Genere = reader["Album"].ToString(),
                    Durata = Convert.ToInt32(reader["Durata"])
                };
                filmList.Add(film);
            }
            return braniList;
        }

        public int AggiungiSpettatore(SpettatoreViewModel spettatore)
        {
            string sql = @"INSERT INTO Spettatore
            ([Nome]
           ,[Cognome]
           ,[DataNascita]
           VALUES (@Nome,@Cognome,@DataNascita) ";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Nome", spettatore.Nome);
            command.Parameters.AddWithValue("@Cognome", spettatore.Cognome);
            command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);
            
            return command.ExecuteNonQuery();
        }

        public int AggiungiFilm(FilmViewModel film)
        {
            string sql = @"INSERT INTO Film
            ([Titolo]
           ,[Autore]
           ,[Produttore]
           ,[Genere]
           ,[Durata]
           VALUES (@Titolo,@Autore,@Produttore,@Genere,@Durata) ";
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
           ,[CodFilm]
           
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
        public int SvuotaSala(SalaViewModel sala)
        {
            string sql = @"UPDATE SalaCinematografica
                       SET [Capienza] = @Capienza
                          
                     WHERE IDSala =@IDSala";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Capienza", sala.Capienza);

            return command.ExecuteNonQuery();
        }

        public int IncassoCinema(SalaViewModel sala)
        {
            string sql = @"SELECT SUM(IncassoSala) AS 'TOTALE_INCASSO'
            FROM [dbo].[SalaCinematografica]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IncassoSala", sala.IncassoSala);

            return command.ExecuteNonQuery();
        }

        public int IncassoSala(SalaViewModel sala)
        {
            string sql = @"SELECT SUM(IncassoSala) AS 'TOTALE_INCASSO'
            FROM [dbo].[SalaCinematografica]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IncassoSala", sala.IncassoSala);

            return command.ExecuteNonQuery();
        }

    }

}

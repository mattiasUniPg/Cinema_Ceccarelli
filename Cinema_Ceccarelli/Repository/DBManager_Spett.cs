using Cinema_Ceccarelli.Models;
using System.Data.SqlClient;

namespace Cinema_Ceccarelli.Repository
{
    public class DBManager_Spett
    {

        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = CINEMA; Trusted_Connection = True;";
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
        public int ScontoAnziani(SpettatoreViewModel spettatore)
        {
            string sql = @"SELECT(Biglietto.Prezzo*0.9) AS 'Sconto_A'
            FROM[dbo].[Biglietto]
            INNER JOIN Spettatore ON Biglietto.IDBiglietto=Spettatore.CodBiglietto
            WHERE Spettatore.DataNascita >='01-01-1952';";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);

            return command.ExecuteNonQuery();
        }

        public int ScontoBimbi(SpettatoreViewModel spettatore)
        {
            string sql = @"SELECT (Biglietto.Prezzo*0.5) AS 'Sconto_B'
            FROM [dbo].[Biglietto]
            INNER JOIN Spettatore ON Biglietto.IDBiglietto=Spettatore.CodBiglietto
            WHERE Spettatore.DataNascita <='01-01-2017';";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);

            return command.ExecuteNonQuery();
        }
        public int Horror14(SpettatoreViewModel spettatore)
        {
            string sql = @"CASE
                WHEN DataNascita > '2008-01-01' THEN 0  ELSE 1
                END AS 'IsMaggiorenne' FROM Spettatore;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@DataNascita", spettatore.DataNascita);

            return command.ExecuteNonQuery();
        }

    }
}

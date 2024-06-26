﻿using Cinema_Ceccarelli.Models;
using System.Data.SqlClient;

namespace Cinema_Ceccarelli.Repository
{
    public class DBManager_SaleCinema
    {

        private static string connectionString = @"Server = ACADEMYNETPD04\SQLEXPRESS; Database = CINEMA; Trusted_Connection = True;";
        public int IncassoCinema(CinemaViewModel cinema)
        {
            string sql = @"SELECT SUM(IncassoGiornaliero) AS 'TOTALE_INCASSO'
            FROM [dbo].[Cinema]";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IncassoGiornaliero", cinema.IncassoGiornaliero);

            return command.ExecuteNonQuery();
        }

        public int IncassoSala(SalaViewModel sala)
        {
            string sql = @"SELECT SalaCinematografica.IDSala, SUM(Biglietto.Prezzo*SalaCinematografica.NumBiglietti) AS 'IncassoSala'
                            FROM [dbo].[Biglietto]
                            INNER JOIN SalaCinematografica ON SalaCinematografica.IDSala=Biglietto.CodSala
                            GROUP BY SalaCinematografica.IDSala;";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IncassoSala", sala.IncassoSala);

            return command.ExecuteNonQuery();
        }
        public int SvuotaSala(SalaViewModel sala)
        {
            string sql = @"UPDATE SalaCinematografica
                       SET [Capienza] = 250
                     WHERE IDSala =@IDSala";
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Capienza", sala.Capienza);

            return command.ExecuteNonQuery();
        }
    }
}

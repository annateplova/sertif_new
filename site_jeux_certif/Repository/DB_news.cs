using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using site_jeux_certif.Models;

namespace site_jeux_certif.Repository
{
    internal class DB_news
    {
        public int AddNews(int idNews, DateTime datePostNews, string? newsName, string textNews, int refIdAdminNews, string? fileUrl)
        {
            Connection connection = new();
            SqlConnection connect = connection.GetConnection();

            SqlCommand command = connect.CreateCommand(); //Demande Création d'une requête (InstructionrefIdAdminNews
            command.CommandText = $"INSERT INTO news (newsId, datePostNews, newsName, textNews) VALUES ( {idNews}, '{datePostNews}', '{newsName}', '{textNews}', {refIdAdminNews}, '{fileUrl}' )"; // Prépare Création de la requête
            int rowAffected = command.ExecuteNonQuery(); //avant signe egalite: variable qui contien le resultat de function; aprés signe egalite: Exécution de la commande        

            connect.Close();
            return rowAffected;
        }
        public List<news> AfficherNews() // pour afficher activités
        {
            Connection connection = new Connection();
            SqlConnection connect = connection.GetConnection();

            SqlCommand RequestFromDB = connect.CreateCommand();
            RequestFromDB.CommandText = "SELECT * FROM news";

            List<news> news = new List<news>();
            SqlDataReader resultat = RequestFromDB.ExecuteReader();

            while (resultat.Read())
            {
                int newsId = resultat.GetInt32(resultat.GetOrdinal("newsId"));
                DateTime datePostNews = resultat.GetDateTime(resultat.GetOrdinal("datePostNews"));
                string newsName = resultat.GetString(resultat.GetOrdinal("newsName"));
                string textNews = resultat.GetString(resultat.GetOrdinal("textNews"));
                int refIdAdminNews = resultat.GetInt32(resultat.GetOrdinal("refIdAdminNews"));
                string fileUrl = resultat.GetString(resultat.GetOrdinal("fileUrl"));

                news News = new news(newsId, datePostNews, newsName, textNews, refIdAdminNews, fileUrl);
                news.Add(News);
            }
            connect.Close();
            return news;
        }

        public int UpdateNews(int idNews, DateTime datePostNews, string? newsName, string textNews, int refIdAdminNews, string? fileUrl)
        {
            Connection connection = new();
            SqlConnection connect = connection.GetConnection();

            SqlCommand command = connect.CreateCommand(); // Demande Création d'une requête (Instanciation) 
            command.CommandText = $"UPDATE NEWS SET datePostNews = '{datePostNews}', newsName = '{newsName}', textNews = '{textNews}', refIdAdminNews = {refIdAdminNews}, fileUrl = '{fileUrl}' WHERE idNews = {idNews}"; // Prépare Création de la requête
            int rowAffected = command.ExecuteNonQuery(); //avant  signe egalite : variable qui contien le resultat de function; aprés signe egalite : Exécution de la commande 

            connect.Close();
            return rowAffected;
        }
        public int DeleteNews(int idNews)
        {
            Connection connection = new();
            SqlConnection connect = connection.GetConnection();

            SqlCommand command = connect.CreateCommand(); // Demande Création d'une requête (Instanciation) 
            command.CommandText = $"DELETE FROM NEWS WHERE newsId = {idNews}"; // Prépare Création de la requête
            int rowsAffected = command.ExecuteNonQuery(); //avant  signe egalite : variable qui contien le resultat de function; aprés signe egalite : Exécution de la commande 

            connect.Close();
            return rowsAffected;
        }
    }
}

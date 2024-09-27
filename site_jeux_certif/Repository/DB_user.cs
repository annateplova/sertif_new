using site_jeux_certif.Models;

namespace site_jeux_certif.Repository
    {
    public class UtilisateurRepository : InterfaceUtilisateurRepository
    {
        private readonly InterfaceConnexion _interfaceConnection;
        public UtilisateurRepository(InterfaceConnexion interfaceConnexion)
        {
            _interfaceConnection = interfaceConnexion;
        }
        public IEnumerable<Utilisateur> GetAll()
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM Utilisateur";
            return connection.Query<Utilisateur>(requete);
        }
        public Utilisateur GetById(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "SELECT * FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur";
            return connection.QueryFirstOrDefault<Utilisateur>(requete, new { id_Utilisateur = id });
        }
        public void Add(Utilisateur utilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            VerificationChampsExistants(utilisateur);
            string requete = "INSERT INTO Utilisateur(idStatut, id_vCode, uNom, uPrenom, Email, uIdentifiant, uMotDePasse, Adresse1)" +
                "VALUES (@idStatut, @id_vCode, @uNom, @uPrenom, @Email, @uIdentifiant, @uMotDePasse, @Adresse1)";
            connection.Execute
                (requete, utilisateur);
        }
        public void Update(Utilisateur utilisateur)
        {
            VerificationDeChamps(utilisateur);

            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "UPDATE Utilisateur SET idStatut = @idStatut, id_vCode = @id_vCode, uNom = @uNom, uPrenom = @uPrenom, Email = @Email," +
                "uIdentifiant = @uIdentifiant, uMotDePasse = @uMotDePasse, Adresse1 = @Adresse1 WHERE id_Utilisateur = @id_Utilisateur";
            connection.Execute(requete, utilisateur);
        }

        public void Delete(int id)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "DELETE FROM Utilisateur WHERE id_Utilisateur = @id_Utilisateur";
            connection.Execute(requete, new { id_Utilisateur = id });
        }

        public void VerificationDeChamps(Utilisateur unUtilisateur)
        {
            // Validation des données de l'utilisateur
            if (unUtilisateur == null)
            {
                throw new ArgumentNullException(nameof(unUtilisateur), "L'utilisateur ne peut pas être nul.");
            }

            if (unUtilisateur.id_Utilisateur <= 0)
            {
                throw new ArgumentException("L'ID utilisateur doit être supérieur à 0.", nameof(unUtilisateur.id_Utilisateur));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.uNom))
            {
                throw new ArgumentException("Le nom de l'utilisateur ne peut pas être vide.", nameof(unUtilisateur.uNom));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.uPrenom))
            {
                throw new ArgumentException("Le prénom de l'utilisateur ne peut pas être vide.", nameof(unUtilisateur.uPrenom));
            }

            if (string.IsNullOrWhiteSpace(unUtilisateur.Email) || !IsValidEmail(unUtilisateur.Email))
            {
                throw new ArgumentException("L'adresse email de l'utilisateur est invalide.", nameof(unUtilisateur.Email));
            }
        }

        public void VerificationChampsExistants(Utilisateur unUtilisateur)
        {
            using var connection = _interfaceConnection.CreateConnexion();
            string requete = "select count(*) as Count from Utilisateur where Email = @Email";
            dynamic result = connection.Query(requete, unUtilisateur).Single();
            int count = result.Count;
            if (count > 0)
            {
                throw new ArgumentException("L'adresse email de l'utilisateur existe déjà.", nameof(unUtilisateur.Email));
            }
        }

        private bool IsValidEmail(string email)
        {
            //Validation du champ mail
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
/*    public class DB_user
    {
        public int AddUser(int idAd, string nomAd, string prenomAd, string email, string mot_passe, string loginAd, string adr1Ad, int ref_CP_Ad)
        {
            Connection connection = new();
            SqlConnection conect = connection.GetConnection();

            SqlCommand command = conect.CreateCommand(); // Demande Création d'une requête (Instanciation) 
            command.CommandText = $"INSERT INTO userJR (idAd, nomAd, prenomAd, email, mot_passe, loginAd, adr1Ad, ref_CP_Ad) VALUES ({idAd}, '{nomAd}', '{prenomAd}', '{email}', '{mot_passe}', '{loginAd}', '{adr1Ad}', {ref_CP_Ad})"; // Prépare Création de la requête

            int rowAffected = command.ExecuteNonQuery();  //avant  signe egalite : variable qui contien le resultat de function; aprés signe egalite : Exécution de la commande 

            conect.Close();
            return rowAffected;

        }
        public List<userJR> AfficherUsers()
        {             // pour afficher les adhérents
            Connection connection = new Connection();
            SqlConnection connection1 = connection.GetConnection();

            SqlCommand RequestGetFromBD = connection1.CreateCommand();
            RequestGetFromBD.CommandText = "SELECT * FROM userJR";

            List<userJR> user = new List<userJR>();

            SqlDataReader resultat = RequestGetFromBD.ExecuteReader();

            while (resultat.Read())
            {
                int idUser = resultat.GetInt32(resultat.GetOrdinal("idUser"));
                string userFirstName = resultat.GetString(resultat.GetOrdinal("userFirstName"));
                string userLastName = resultat.GetString(resultat.GetOrdinal("userLastName"));
                string adr1User = resultat.GetString(resultat.GetOrdinal("adr1User"));
                string adr2User = resultat.GetString(resultat.GetOrdinal("adr2User"));
                string emailUser = resultat.GetString(resultat.GetOrdinal("emailUser"));
                string passwordUser = resultat.GetString(resultat.GetOrdinal("passwordUser"));
                int refIdCity = resultat.GetInt32(resultat.GetOrdinal("refIdCity"));

                if (resultat.IsDBNull(resultat.GetOrdinal("adr2Ad")))

                {
                    adr2A = "";
                }
                else
                {
                    adr2A = resultat.GetString(resultat.GetOrdinal("adr2Ad"));
                }

                int ref_CP_A = resultat.GetInt32(resultat.GetOrdinal("ref_CP_Ad"));
                userJR users = new user(idA, nomA, prenomA, emailA, mot_passeA, loginA, adr1A, adr2A, ref_CP_A);
                user.Add(user);

            }
            connection1.Close();
            return adherents;

        }
        public int UpdateAd(int idAd, string nomAd, string prenomAd, string email, string mot_passe, string loginAd, string adr1Ad, string adr2Ad, int ref_CP_Ad)
        {
            Connection connection = new();
            SqlConnection connect = connection.GetConnection();

            SqlCommand command = connect.CreateCommand();// Demande Création d'une requête (Instanciation) 
            command.CommandText = $"UPDATE adherent SET nomAd='{nomAd}', prenomAd = '{prenomAd}', email = '{email}', mot_passe = '{mot_passe}', loginAd = '{loginAd}', adr1Ad = '{adr1Ad}', adr2Ad='{adr2Ad}', ref_CP_Ad={ref_CP_Ad} WHERE idAd = {idAd}"; // Prépare Création de la requête
            int rowAffected = command.ExecuteNonQuery(); //avant  signe egalite : variable qui contien le resultat de function; aprés signe egalite : Exécution de la commande 

            connect.Close();
            return rowAffected;
        }
        public int DeleteAdherent(int id)
        {
            Connection connection = new();
            SqlConnection connect = connection.GetConnection();

            SqlCommand command = connect.CreateCommand();// Demande Création d'une requête (Instanciation) 
            command.CommandText = $"DELETE FROM adherent WHERE idAd = {id}"; // Prépare Création de la requête
            int rowAffected = command.ExecuteNonQuery(); //avant  signe egalite : variable qui contien le resultat de function; aprés signe egalite : Exécution de la commande 

            connect.Close();
            return rowAffected;
        }
    }
}
}
*/
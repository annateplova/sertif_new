using site_jeux_certif.Models;
using Dapper;
using site_jeux_certif.Repository;

namespace site_jeux_certif.Repository
{
    public class userRepository : interfaceUserRepository
    {
            private readonly interfaceConnexion _interfaceConnection;
            public userRepository(interfaceConnexion interfaceConnexion)
            {
                _interfaceConnection = interfaceConnexion;
            }
            public IEnumerable<userJR> GetAll()
            {
                using var connection = _interfaceConnection.CreateConnexion();
                string requete = "SELECT * FROM userJR";
                return connection.Query<userJR>(requete);
            }
            public userJR GetById(int id)
            {
                using var connection = _interfaceConnection.CreateConnexion();
                string requete = "SELECT * FROM userJR WHERE idUser = @idUser";
                return connection.QueryFirstOrDefault<userJR>(requete, new { idUser = id });
            }
            public void Add(userJR userJR)
            {
                using var connection = _interfaceConnection.CreateConnexion();
                VerificationChampsExistants(userJR);
                string requete = "INSERT INTO userJR(idUser, userFirstName, userLastName, adr1User, adr2User, refIdCity, emailUser, passwordUser, refIdRoleUser )" +
                    "VALUES (@idUser, @userFirstName, @userLastName, @adr1User, @adr2User, @refIdCity, @emailUser, @passwordUser, @refIdRoleUser)";
                connection.Execute
                    (requete, user);
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

using System.Data;
using Microsoft.Data.SqlClient;

namespace site_jeux_certif.Repository
{
    public class generateurConnexion
    {
        private readonly string _ligneDeConnexion;
        public generateurConnexion(string uneLigneDeConnexion)
        {
            _ligneDeConnexion = uneLigneDeConnexion;
        }
        public IDbConnection CreateConnexion()
        {
            return new SqlConnection(_ligneDeConnexion);
        }
    }
}

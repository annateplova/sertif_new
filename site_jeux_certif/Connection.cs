using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace site_jeux_certif
{
    public class Connection
    {
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(@"Data source=DESKTOP-BDI19CI\ANNA;Initial Catalog=jeux_roles;Persist Security Info=True;User ID=sa;Password=hera8281");
            SqlCommand command = connection.CreateCommand();
            connection.Open();
            return connection;
        }
    }
}

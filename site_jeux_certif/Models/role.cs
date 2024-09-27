using Microsoft.AspNetCore.Rewrite;

namespace site_jeux_certif.Models
{
    public class role
    {
        public int idRole { get; set; }
        public string roleJR { get; set; }
     

    //constructeur
    public role(int un_idRole, string un_roleJR)
    {
        idRole = un_idRole;
        roleJR = un_roleJR;
    }
    }
}

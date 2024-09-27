namespace site_jeux_certif.Models
{
    public class admin
    {
        public int idAdmin { get; set; }
        public string adminFirstName { get; set; }
        public string adminLastName { get; set; }
        public string emailAdmin { get; set; }
        public string passwordAdmin { get; set; }
        public int refIdRoleAdmin { get; set; }

        //constructeur

        public admin(int un_idAdmin, string un_adminFirstName, string un_adminLastName, string un_emailAdmin, string un_passwordAdmin, int un_refIdRoleAdmin)
        {
            idAdmin = un_idAdmin;
            adminFirstName = un_adminFirstName;
            adminLastName = un_adminLastName;
            emailAdmin = un_emailAdmin;
            passwordAdmin = un_passwordAdmin;
            refIdRoleAdmin = un_refIdRoleAdmin;
        }
    }
}

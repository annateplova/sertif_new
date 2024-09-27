namespace site_jeux_certif.Models
{
    public class userJR
    {
        public int idUser { get; set; }
        public string userFirstName { get; set; }
        public string userLastName { get; set; }
        public string adr1User { get; set; }
        public string? adr2User { get; set; }
        public int refIdCity { get; set; }
        public string emailUser { get; set; }
        public string passwordUser { get; set; }
        public int refIdRoleUser { get; set; }

        //constructeur
      /*  public userJR(int un_idUser, string un_userFirstName, string un_userLastName, string un_adr1User, string un_adr2User, int un_refIdCity, string un_emailUser, string un_passwordUser, int un_refIdRoleUser)
        {
            idUser = un_idUser;
            userFirstName = un_userFirstName;
            userLastName = un_userLastName;
            adr1User = un_adr1User;
            adr2User = un_adr2User;
            refIdCity = un_refIdCity;
            emailUser = un_emailUser;
            passwordUser = un_passwordUser;
            refIdRoleUser = un_refIdRoleUser;

        }*/
    }
}

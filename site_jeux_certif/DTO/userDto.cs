namespace site_jeux_certif.DTO
{
    public class userDto
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
    }
}

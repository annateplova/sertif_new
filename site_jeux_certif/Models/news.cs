namespace site_jeux_certif.Models
{
    public class news
    {
        public int idNews { get; set; }
        public DateTime datePostNews { get; set; }
        public string? newsName { get; set; }
        public string textNews { get; set; }
        public  int refIdAdminNews { get; set; }
        public string? fileUrl { get; set; }


        //constructeur
        public news(int un_idNews, DateTime un_datePostNews, string un_newsName, string un_textNews, int un_refIdAdminNews, string un_fileUrl)
        {
            idNews = un_idNews;
            datePostNews = un_datePostNews;
            newsName = un_newsName;
            textNews = un_textNews;
            refIdAdminNews = un_refIdAdminNews;
            fileUrl = un_fileUrl;
        }
    }
}

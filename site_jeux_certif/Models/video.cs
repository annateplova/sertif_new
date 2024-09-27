namespace site_jeux_certif.Models
{
    public class video
    {
        public int idVideo { get; set; }
        public DateTime datePostVideo { get; set; }
        public string videoName { get; set; }
        public string videoUrl { get; set; }
        public string? videoDescription { get; set; }
        public int refIdAdminVideo { get; set; }

        //constructeur 

        public video(int un_idVideo, DateTime un_datePostVideo, string un_videoName, string un_videoUrl, string un_videoDescription)
        {
            idVideo = un_idVideo;
            datePostVideo = un_datePostVideo;
            videoName = un_videoName;
            videoUrl = un_videoUrl;
            videoDescription = un_videoDescription;
            videoDescription = un_videoDescription;
        }
    }
}

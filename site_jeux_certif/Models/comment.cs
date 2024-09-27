namespace site_jeux_certif.Models
{
    public class comment
    {
        public int idComment { get; set; }
        public string commentJR { get; set; }
        public DateTime dateComment { get; set; }
        public int refIdUserComment { get; set; }
        public int? refIdNewsComment { get; set; }
        public int? refIdVideoComment { get; set; }

        //constructeur

        public comment(int un_idComment, string un_commentJR, DateTime un_dateComment, int un_refIdUserComment, int un_refIdNewsComment, int un_refIdVideoComment)
        {
            idComment = un_idComment;
            commentJR = un_commentJR;
            dateComment = un_dateComment;
            refIdUserComment = un_refIdUserComment;
            refIdNewsComment = un_refIdNewsComment;
            refIdVideoComment = un_refIdVideoComment;
        }
    }
}

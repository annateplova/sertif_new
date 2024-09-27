namespace site_jeux_certif.Models
{
        internal class likeJR
        {
            public int idLike { get; set; }
            public DateTime dateLike { get; set; }
            public int refIdUserLike { get; set; }
            public int? refIdNewsLike { get; set; }
            public int? refIdVideoLike { get; set; }


            //constructeur

            public likeJR(int un_idLike, DateTime un_dateLike, int un_refIdUserLike, int un_refIdNewsLike, int un_refIdVideoLike)
            {
            idLike = un_idLike;
            dateLike = un_dateLike;
            refIdUserLike = un_refIdUserLike;
            refIdNewsLike = un_refIdNewsLike;
            refIdVideoLike = un_refIdVideoLike;
            }
        }
    }


namespace site_jeux_certif.Models
{
    public class city
    {
        public int idCity { get; set; }
        public int postalCode { get; set; }
        public string cityJR { get; set; }


        //constructeur
        public city(int un_idCity, int un_postalCode, string un_cityJR)
        {
            idCity = un_idCity;
            postalCode = un_postalCode;
            cityJR = un_cityJR;
        }
    }
}

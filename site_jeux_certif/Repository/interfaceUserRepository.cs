using site_jeux_certif.Models;

namespace site_jeux_certif.Repository
{
    public class interfaceUserRepository
    {
        IEnumerable<userJR> GetAll();
        userJR GetById(int id);
        //void Add(userJR userJR);
        userJR Add(userJR userJR);
        void Update(userJR userJR);
        //void Update((userJR userJR);
        void Delete(int id);
        //ImplentationConnexion
        userJR GetPass(string email, string password);
    }
}

using site_jeux_certif.Models;

namespace site_jeux_certif.Business
{
    public interface interfaceUserService
    {    
        IEnumerable<userJR> GetAllUsers();
        userJR GetUserById(int id);
        //void CreateUser(user user);
        userJR CreateUser(userJR userJR);
        void UpdateUser(userJR userJR);
        //void UpdateUser;
        void DeleteUser(int id);
        userJR GetUserByEmailAndPassword(string email, string password);

    }
}

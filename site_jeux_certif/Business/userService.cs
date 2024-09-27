using site_jeux_certif.Models;
using site_jeux_certif.Repository;

namespace site_jeux_certif.Business
{
    public class userService : interfaceUserService
    {
        private readonly interfaceUserRepository _interfaceUserRepository;
        public userService (interfaceUserRepository interfaceUserRepository)
        {
            _interfaceUserRepository = interfaceUserRepository;
        }
        public IEnumerable<userJR> GetAllUsers()
        {
            return _interfaceUserRepository.GetAll();
        }
        public Interlocuteur GetInterlocuteurById(int id)
        {
            return _interfaceInterlocuteurRepository.GetById(id);
        }

        //public void CreateInterlocuteur(Interlocuteur interlocuteur)
        //{
        //    _interfaceInterlocuteurRepository.Add(interlocuteur);
        //}
        public Interlocuteur CreateInterlocuteur(Interlocuteur interlocuteur)
        {
            return _interfaceInterlocuteurRepository.Add(interlocuteur);
        }

        public void UpdateInterlocuteur(Interlocuteur interlocuteur)
        {
            _interfaceInterlocuteurRepository.Update(interlocuteur);
        }

        //public void UpdateInterlocuteur(Interlocuteur interlocuteur)
        //{
        //    _interfaceInterlocuteurRepository.Update(interlocuteur);
        //}

        public void DeleteInterlocuteur(int id)
        {
            _interfaceInterlocuteurRepository.Delete(id);
        }

        //Implémentation de fonctionnalité connexion
        public Interlocuteur GetUserByEmailAndPassword(string email, string password)
        {
            return _interfaceInterlocuteurRepository.GetPass(email, password);
        }

    }
}
    }
}

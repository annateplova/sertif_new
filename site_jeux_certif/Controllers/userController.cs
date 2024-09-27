using Microsoft.AspNetCore.Mvc;
using site_jeux_certif.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site_jeux_certif.Business;
using site_jeux_certif.Models;


namespace site_jeux_certif.Controllers
{
    public class userController : ControllerBase
    {
        [Route("api/connection")]
        [ApiController]
        public class InterlocuteurController : ControllerBase
        {
            private readonly interfaceUserService _interfaceUserService;
            public InterlocuteurController(interfaceUserService interfaceUserService)
            {
                _interfaceUserService = interfaceUserService;
            }
            [HttpGet]
            public ActionResult<IEnumerable<userJR>> Get()
            {
                var user = _interfaceUserService.GetAllUsers();
                return Ok(user);
            }
            [HttpGet("{id}")]
            public ActionResult<userJR> Get(int id)
            {
                var user = _interfaceUserService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            //tentative de modification de la méthode post pour qu'elle retourne l'utilisateur nouvellement créé.
            [HttpPost]
            public ActionResult<userJR> Post([FromBody] userJR user)
            {
                var createdUser = _interfaceUserService.CreateUser(user);
                if (createdUser == null)
                {
                    return BadRequest("Erreur de création d'utilisateur.");
                }
                return CreatedAtAction(nameof(Get), new { id = createdUser.idUser }, createdUser);
            }

            //MISE À JOUR DE L'UTILISATEUR AVEC RETOUR DE L'UTILISATEUR MODIFIÉ
            [HttpPut("{id}")]
            public ActionResult<userJR> Put(int id, [FromBody] userJR userJR)
            {
                if (id != userJR.idUser)
                {
                    return BadRequest();
                }
                _interfaceUserService.UpdateUser(userJR);
                var userModif = _interfaceUserService.GetUserById(id);
                return Ok(userModif);
            }

            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                _interfaceUserService.DeleteUser(id);
                return NoContent();
            }

            //Implémentation de connexion
            [HttpPost("login")]
            public ActionResult Login([FromBody] userLogin userLogin)
            {
                var user = _interfaceUserService.GetUserByEmailAndPassword(userLogin.email, userLogin.password);

                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user);
            }

        }
    }
}

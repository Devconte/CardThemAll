using Microsoft.AspNetCore.Mvc;
using CardThemAll.Models;

namespace CardThemAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>();

        // 1️⃣ Créer un utilisateur
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = _users.Count + 1; // Générer un ID unique
            _users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // 2️⃣ Récupérer un utilisateur par ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("Utilisateur non trouvé.");

            return Ok(user);
        }

        // 3️⃣ Récupérer tous les utilisateurs
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }
    }
}
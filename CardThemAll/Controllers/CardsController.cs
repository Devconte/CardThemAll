using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CardThemAll.Models;

namespace CardThemAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private static List<Card> _cards = new List<Card>
        {
            new Card { Id = 1, Name = "Dracaufeu", Set = "Base Set", Type = "Feu", HP = 120, Image = "https://example.com/dracaufeu.jpg" },
            new Card { Id = 2, Name = "Tortank", Set = "Base Set", Type = "Eau", HP = 100, Image = "https://example.com/tortank.jpg" },
            new Card { Id = 3, Name = "Florizarre", Set = "Base Set", Type = "Plante", HP = 100, Image = "https://example.com/florizarre.jpg" }
        };

        // 1️⃣ Récupérer toutes les cartes
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetCards()
        {
            return Ok(_cards);
        }

        // 2️⃣ Récupérer une carte par ID
        [HttpGet("{id}")]
        public ActionResult<Card> GetCard(int id)
        {
            var card = _cards.FirstOrDefault(c => c.Id == id);
            if (card == null)
                return NotFound("Carte non trouvée.");

            return Ok(card);
        }

  
    }
}

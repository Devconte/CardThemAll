using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CardThemAll.Models;

namespace CardThemAll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private static List<Collection> _collections = new List<Collection>();
        private static List<CollectionCard> _collectionCards = new List<CollectionCard>();

        // 1️⃣ Créer une nouvelle collection pour un utilisateur
        [HttpPost]
        public ActionResult CreateCollection(Collection collection)
        {
            collection.Id = _collections.Count + 1;
            _collections.Add(collection);
            return Ok("Collection créée !");
        }

        // 2️⃣ Récupérer les collections d'un utilisateur
        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Collection>> GetCollections(int userId)
        {
            var userCollections = _collections.Where(c => c.UserId == userId).ToList();
            return Ok(userCollections);
        }

        // 3️⃣ Ajouter une carte à une collection
        [HttpPost("add-card")]
        public ActionResult AddCardToCollection(CollectionCard collectionCard)
        {
            var existing = _collectionCards.FirstOrDefault(cc => cc.CollectionId == collectionCard.CollectionId && cc.CardId == collectionCard.CardId);
            if (existing != null)
            {
                existing.Quantity += collectionCard.Quantity;
            }
            else
            {
                collectionCard.Id = _collectionCards.Count + 1;
                _collectionCards.Add(collectionCard);
            }

            return Ok("Carte ajoutée à la collection !");
        }

        // 4️⃣ Récupérer les cartes d'une collection
        [HttpGet("cards/{collectionId}")]
        public ActionResult<IEnumerable<CollectionCard>> GetCollectionCards(int collectionId)
        {
            var cards = _collectionCards.Where(cc => cc.CollectionId == collectionId).ToList();
            return Ok(cards);
        }

        // 5️⃣ Retirer une carte d'une collection
        [HttpPost("remove-card")]
        public ActionResult RemoveCardFromCollection(CollectionCard collectionCard)
        {
            var existing = _collectionCards.FirstOrDefault(cc => cc.CollectionId == collectionCard.CollectionId && cc.CardId == collectionCard.CardId);
            if (existing != null)
            {
                existing.Quantity -= collectionCard.Quantity;
                if (existing.Quantity <= 0)
                    _collectionCards.Remove(existing);
            }

            return Ok("Carte retirée de la collection !");
        }
    }
}

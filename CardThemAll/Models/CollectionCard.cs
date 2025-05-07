namespace CardThemAll.Models
{
    public class CollectionCard
    {
        public int Id { get; set; } // ID unique de la relation
        public int CollectionId { get; set; } // Référence à la collection
        public int CardId { get; set; } // Référence à la carte Pokémon
        public int Quantity { get; set; } // Nombre de cette carte dans la collection
        public string Condition { get; set; } // Condition de la carte
        public bool isTradeable { get; set; } // Si le user souhaite l'échanger oun on
    }
}
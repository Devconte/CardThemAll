namespace CardThemAll.Models
{
    public class Collection
    {
        public int Id { get; set; } // ID unique de la collection
        public int UserId { get; set; } // Propriétaire de la collection
        public string Name { get; set; } // Nom de la collection (ex: "Collection de Feu")
    }
}
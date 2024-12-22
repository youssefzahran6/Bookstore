using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensures auto-increment behavior
        public int Id { get; set; }

        public required string Title { get; set; }

        public required string Author { get; set; }

        public required string ISBN { get; set; }

        public required decimal Price { get; set; }
    }
}
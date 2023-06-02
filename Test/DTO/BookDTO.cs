using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Test.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? AuthorName { get; set; }
        public int PublishYear { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
    }
}

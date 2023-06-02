using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel;
//using System.Text.Json.Serialization;

namespace Test.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? AuthorName { get; set; }
        public int PublishYear { get; set; }
        [ForeignKey("AuthorId")]        
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author? Author { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
    }
}

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
        public bool Female { get; set; }
        public int Born { get; set; }
        public int? Died { get; set; }
        public int? age { get; set; }
    }
}

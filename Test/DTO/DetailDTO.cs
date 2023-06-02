namespace Test.DTO
{
    public class DetailDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Topic { get; set; }
        public string? AuthorName { get; set; }
        public int PublishYear { get; set; }
        public AuthorDTO? Author { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
    }
}

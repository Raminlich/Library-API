namespace Library_API.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public int PublishedYear { get; set; }
    }
}

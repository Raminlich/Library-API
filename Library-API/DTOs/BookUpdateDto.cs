namespace Library_API.DTOs
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public int PublishedYear { get; set; }
    }
}

namespace Domain.Models.DTOs;

public class GetBookWithAuthorDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int PublishedYear { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
    public List<Author> Authors { get; set; }
}
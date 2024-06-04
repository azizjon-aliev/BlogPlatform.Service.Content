namespace Content.API.DTO;

public class UpdatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}
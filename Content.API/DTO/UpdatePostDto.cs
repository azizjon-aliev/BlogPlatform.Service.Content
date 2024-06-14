namespace Content.API.DTO;

public class UpdatePostDto
{
    public IFormFile Image { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid CategoryId { get; set; }
}
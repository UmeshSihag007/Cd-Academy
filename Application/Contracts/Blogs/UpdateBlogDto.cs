namespace Application.Contracts.Blogs;

public class UpdateBlogDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string ThumbImage { get; set; }
    public DateTime TotalReadTime { get; set; }
    public DateTime TotalPracticeTime { get; set; }
    public int? CategoryId { get; set; }
    public int? AuthorId { get; set; }
    public string ReaderHint { get; set; }
}

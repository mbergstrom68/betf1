namespace BlazorApp.Client.Models
{
    public class NewsModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public DateTime? PublishingDate { get; set; }
        public Uri? ImageUrl { get; set; }
        public Uri? Alt { get; set; }
    }
}

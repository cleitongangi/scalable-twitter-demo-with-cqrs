namespace TwitterDemo.Domain.Commands.Posts.NewPost
{
    public class NewPostResult : CommandResponseBase
    {
        public long Id { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }        
    }
}

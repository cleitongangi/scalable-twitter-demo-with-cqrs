using MediatR;

namespace TwitterDemo.Domain.Commands.Posts.NewPost
{
    public class NewPostCommand : IRequest<NewPostResult>
    {
        public long UserId { get; private set; }
        public string? Text { get; set; }        

        public void SetUserId(long userId)
        {
            UserId = userId;
        }
    }
}

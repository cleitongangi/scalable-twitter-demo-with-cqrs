using MediatR;

namespace TwitterDemo.Domain.Queries.User.GetUser
{
    public class GetUserQueryRequest : IRequest<GetUserQueryResult>
    {
        public long UserId { get; set; }
    }
}

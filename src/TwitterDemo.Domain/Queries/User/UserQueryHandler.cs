using MediatR;
using TwitterDemo.Domain.Queries.User.GetUser;

namespace TwitterDemo.Domain.Queries.User
{
    public class UserQueryHandler : IRequestHandler<GetUserQueryRequest, GetUserQueryResult>
    {
        public async Task<GetUserQueryResult> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            // TODO: For test only. Must implement the right rule. 
            var result = new GetUserQueryResult(request.UserId, "Cleiton", new DateTime(2022,10,11), 2, 9, 15, true);
            return result;
        }
    }
}

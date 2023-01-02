namespace TwitterDemo.Domain.Queries.User.GetUser
{
    public class GetUserQueryResult
    {
        public long UserId { get; }
        public string Username { get; }
        public DateTime JoinedAt { get; }
        public int FollowersCount { get; }
        public int FollowingCount { get; }
        public int PostsCount { get; }
        public bool Following { get; }

        public GetUserQueryResult(long userId, string username, DateTime joinedAt, int followersCount, int followingCount, int postsCount, bool following)
        {
            UserId = userId;
            Username = username;
            JoinedAt = joinedAt;
            FollowersCount = followersCount;
            FollowingCount = followingCount;
            PostsCount = postsCount;
            Following = following;
        }
    }
}

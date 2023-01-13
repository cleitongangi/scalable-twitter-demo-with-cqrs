using TwitterDemo.Domain.Models;

namespace TwitterDemo.Domain.Interfaces.Repositories
{
    public interface IPostsRepository
    {
        Task<PostEntity> AddAsync(PostEntity entity);
    }
}

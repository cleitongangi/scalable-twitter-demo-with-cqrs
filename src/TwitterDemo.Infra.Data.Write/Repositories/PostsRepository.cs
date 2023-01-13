using TwitterDemo.Domain.Interfaces.Repositories;
using TwitterDemo.Domain.Models;
using TwitterDemo.Infra.Data.Write.Context;

namespace TwitterDemo.Infra.Data.Write.Repositories
{
    public class PostsRepository : IPostsRepository
    {
        private readonly WriteDbContext _db;

        public PostsRepository(WriteDbContext writeDbContext)
        {
            this._db = writeDbContext;
        }

        public async Task<PostEntity> AddAsync(PostEntity entity)
        {
            await _db.Posts.AddAsync(entity);
            return entity;
        }
    }
}

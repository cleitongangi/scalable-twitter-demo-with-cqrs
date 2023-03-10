using TwitterDemo.Domain.Interfaces.Data;

namespace TwitterDemo.Infra.Data.Write.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _db;

        public UnitOfWork(WriteDbContext posterrDb)
        {
            this._db = posterrDb;
        }

        public async Task BeginTransactionAsync()
        {
            if (_db.Database.CurrentTransaction == null)
                await _db.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_db.Database.CurrentTransaction != null)
                await _db.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            if (_db.Database.CurrentTransaction != null)
                await _db.Database.RollbackTransactionAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

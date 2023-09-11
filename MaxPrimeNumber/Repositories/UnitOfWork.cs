using MaxPrimeNumber.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaxPrimeNumber.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed = false;
        
        public UnitOfWork(ApplicationDbContext dbContext) 
            //TODO check if we can use applicationdbcontext in unitofwork
        {
            _dbContext = dbContext;
        }
        public void Commit()
        {
            _dbContext.SaveChanges(); // TODO save changes async olacak
        }
        public void Rollback()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
        public IRepository<T> Repository<T>() where T : BaseEntity
        {
            return new Repository<T>(_dbContext);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
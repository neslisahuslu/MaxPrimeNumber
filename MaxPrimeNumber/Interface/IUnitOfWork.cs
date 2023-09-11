using MaxPrimeNumber.Entities;

namespace MaxPrimeNumber.Repositories;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rollback();
    IRepository<T> Repository<T>() where T : BaseEntity;
}
using MaxPrimeNumber.Entities;

namespace MaxPrimeNumber.Repositories;

public class EnteredNumberRepository : Repository<EnteredNumber>, IEnteredNumberRepository
{
    public EnteredNumberRepository(ApplicationDbContext context) : base(context)
    {
    }
}

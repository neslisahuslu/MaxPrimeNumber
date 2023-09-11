using MaxPrimeNumber.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MaxPrimeNumber.Services.Admin;

public class AdminService : IAdminService
{
    private readonly IEnteredNumberRepository _enteredNumberRepository;

    public AdminService(IEnteredNumberRepository enteredNumberRepository)
    {
        _enteredNumberRepository = enteredNumberRepository;
    }


    public virtual async Task<List<Entities.EnteredNumber>> FindAll()
    {
        return await _enteredNumberRepository.GetAll().ToListAsync();
    }
} // la getAll da hepsini al diyosun kosul yok iceriye neden parametre veriyosun :D getAllUsersde parametre var mi
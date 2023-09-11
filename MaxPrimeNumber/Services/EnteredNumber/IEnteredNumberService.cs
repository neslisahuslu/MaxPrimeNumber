using MaxPrimeNumber.Entities;

namespace MaxPrimeNumber.Services.EnteredNumber
{

    public interface IEnteredNumberService
    {
        Task<bool> InsertAsync(List<int> enteredNumbers, Entities.User user);

        bool IsPrimeNumber(int enteredNumber);

        int FindLargestPrime(List<int> enteredNumbers);
    }
}
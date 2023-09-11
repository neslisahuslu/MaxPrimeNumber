
using System.Runtime.CompilerServices;
using MaxPrimeNumber.Repositories;

namespace MaxPrimeNumber.Services.EnteredNumber
{

    public class EnteredNumberService : IEnteredNumberService
    {
        private readonly IEnteredNumberRepository _enteredNumberRepository;

        public EnteredNumberService(IEnteredNumberRepository enteredNumberRepository)
        {
            _enteredNumberRepository = enteredNumberRepository;
        }

        public virtual async Task<bool> InsertAsync(List<int> EnteredNumbers, Entities.User user)
        {
            //bu method su sekilde olmasi lazim
            //public virtual async Task<bool> InsertAsync(EnteredNumber enteredNumber)
            //await _enteredNumberRepository.AddAsync(enteredNumber); ya oglum diyorum ya bu method sadece insert edcek asal sayiyi falan bulmak icin ayri methodlar olusturacaksin ok
            // bu adamin orneginde savechangesasynci  nasil yapmis turk olan adamdan gencay ona bakarsin yavrum 
            // insert sadece database e yazmaktan sorumlu oldugu icin yukarda commentli olan sekilde olacak
            //bu sekilde database e save ediyor ama solide aykiri dedigin gibi bu da onu nasil yapmis ona bak iste gencaydan okay 

            int maxPrimeNumber = FindLargestPrime(EnteredNumbers);
            var enteredNumber = new Entities.EnteredNumber()
            {
                Id = Guid.NewGuid(),
                EnteredNumberUserId = Guid.NewGuid(),
                EnteredNumbers = string.Join(",", EnteredNumbers),
                MaxPrimeNumber = maxPrimeNumber

            };
            await _enteredNumberRepository.AddAsync(enteredNumber);
            await _enteredNumberRepository.SaveAsync();
            return true;
        }
        
        
        public bool IsPrimeNumber(int enteredNumber)
        {
            bool result = true;
            for (int i = 2; i < enteredNumber - 1; i++)
            {
                if (enteredNumber % i == 0)
                {
                    result = false;
                    i = enteredNumber;
                }
            }

            return result;
        }
        
        public int FindLargestPrime(List<int> enteredNumbers)
        {
            int largestPrime = -1;
            bool primeFound = false;

            foreach (int number in enteredNumbers)
            {
                if (number >= 2 && IsPrimeNumber(number))
                {
                    if (!primeFound || number > largestPrime)
                    {
                        largestPrime = number;
                        primeFound = true;
                    }
                }
            }
            if (primeFound)
            {
                return largestPrime;
            }
            else
            {
                return -1; // Not found prime number
            }
        }
    }
}
    
  
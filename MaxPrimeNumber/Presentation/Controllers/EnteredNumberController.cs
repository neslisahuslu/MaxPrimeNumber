using MaxPrimeNumber.Entities;
using MaxPrimeNumber.Services.EnteredNumber;
using Microsoft.AspNetCore.Mvc;

namespace MaxPrimeNumber.Presentation.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EnteredNumberController : Controller
{
    private readonly IEnteredNumberService _enteredNumberService;
    public EnteredNumberController(IEnteredNumberService enteredNumberService)
    {
        _enteredNumberService = enteredNumberService;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> EnterPrimeNumber(List<int> enteredNumbers)
    {
        var user = new User()
        {
            Id = Guid.NewGuid().ToString(),
            Name = "user"
        };
    
        // Servise girilen sayıları ve kullanıcıyı iletişimde bulunmak için kullanın
        bool result = await _enteredNumberService.InsertAsync(enteredNumbers, user);

        if (result)
        {
            int maxPrimeNumber = _enteredNumberService.FindLargestPrime(enteredNumbers); // Girilen en büyük asal sayıyı bulun
            return Ok(maxPrimeNumber);
        }
        else
        {
            return BadRequest("An error occurred while saving entered numbers.");
        }
    }
    
}

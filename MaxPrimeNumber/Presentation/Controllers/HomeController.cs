using Microsoft.AspNetCore.Mvc;

namespace MaxPrimeNumber.Presentation.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
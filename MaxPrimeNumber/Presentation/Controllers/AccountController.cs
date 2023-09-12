using MaxPrimeNumber.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaxPrimeNumber.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    
    public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("index", "home");
    }
    
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost("loginAction")]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email,
                model.Password, model.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _signInManager.UserManager.GetUserAsync(User);
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Administrator"))
                {
                    return RedirectToAction("index", "home"); 
                    //return RedirectToAction("index", "admin"); TODO create admin page, and redirect user to admin page
                }
                else
                {
                    return RedirectToAction("index", "home");
                }


                
                // if role is admin send it to admin page
                // else index page
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }
        return View(model);
    }

    #region register

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View();
    }


    
    [HttpPost("registerAction")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Copy data from RegisterViewModel to IdentityUser
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

            // Store user data in AspNetUsers database table
            var result = await _userManager.CreateAsync(user, model.Password);

            // If user is successfully created, sign-in the user using
            // SignInManager and redirect to index action of HomeController
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("index", "home");
            }

            // If there are any errors, add them to the ModelState object
            // which will be displayed by the validation summary tag helper
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    #endregion
    
    
}
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Mvc.Net.Models;

namespace RAS.Bootcamp.Mvc.Net.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly AppDbContext _dbContext;

    public AccountController(ILogger<AccountController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Login()
    {
        return View(new LoginRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request)
    {


        if(!ModelState.IsValid){
            return View(request);
        }

        var user = _dbContext.Users
        .FirstOrDefault(x=>x.Username == request.Username && x.Password == request.Password);

        if(user == null){
            ViewBag.ErrorMessage = "Invalid username or password";

            return View(request);
        }

        if(user.Tipe == "PEMBELI"){
            ViewBag.ErrorMessage = "You'r not admin or seller";

            return View(request);
        }

        //Set Authorization data to cookies
        var claims = new List<Claim>
        {
            new Claim("id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("FullName", user.Username),
            new Claim(ClaimTypes.Role, user.Tipe),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, 
            new ClaimsPrincipal(claimsIdentity), 
            authProperties);

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> Logout(){
        
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }

    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request){
        if(!ModelState.IsValid){

            return View(request);
        }

        var newUser = new Models.Entities.User{
            Username = request.Username,
            Password = request.Password,
            Tipe = request.Tipe
        };

        var penjual = new Models.Entities.Penjual{
            IdUser = newUser.Id,
            Alamat = request.Alamat,
            NamaToko = $"TK {request.FullName}",
            User = newUser
        };

        _dbContext.Users.Add(newUser);
        _dbContext.Penjuals.Add(penjual);
        
        _dbContext.SaveChanges();

        return RedirectToAction("Login");
    }
}

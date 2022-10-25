using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities;
using RAS.Bootcamp.Catalog.Mvc.Net.Models;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;
public class AccountController : Controller {
    private readonly ILogger<AccountController> _logger;
    private readonly EMarketDbContext _dbContext;
    public AccountController(ILogger<AccountController> logger, EMarketDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Login() {
        return View(new LoginRequest());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest request) {
        if(!ModelState.IsValid){
            return View(request);
        }

        var user = _dbContext.Users
        .FirstOrDefault(x=>x.Username == request.Username && x.Password == request.Password && x.Tipe == "PEMBELI");

        if(user == null){
            ViewBag.ErrorMessage = "Invalid username or password";

            return View(request);
        }

        //Set Authorization data to cookies
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
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

        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request){
        if(!ModelState.IsValid){

            return View(request);
        }

        var newUser = new User{
            Username = request.Username,
            Password = request.Password,
            Tipe = "PEMBELI"
        };

        var pembeli = new Pembely{
            Alamat = request.Alamat,
            IdUser = newUser.Id,
            IdUserNavigation = newUser,
            NoHp = "62"
        };

        _dbContext.Users.Add(newUser);
        _dbContext.Pembelies.Add(pembeli);
        
        _dbContext.SaveChanges();

        return RedirectToAction("Login");
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Mvc.Net.Models;

namespace RAS.Bootcamp.Mvc.Net.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Forbidden(){
        return View();
    }

    public IActionResult Privacy(){
        return View();
    }
}

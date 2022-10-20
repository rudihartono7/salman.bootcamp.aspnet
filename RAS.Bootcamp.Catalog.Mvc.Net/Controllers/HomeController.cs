using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Models;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EMarketDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, EMarketDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var barang = _dbContext.Barangs.ToList();
        return View(barang);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

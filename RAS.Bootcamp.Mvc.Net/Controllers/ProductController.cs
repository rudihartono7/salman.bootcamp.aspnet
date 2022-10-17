using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Mvc.Net.Models;
using RAS.Bootcamp.Mvc.Net.Models.Entities;

namespace RAS.Bootcamp.Mvc.Net.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly AppDbContext _dbContext;

    public ProductController(ILogger<ProductController> logger, AppDbContext dbContext)
    {
        _dbContext = dbContext;
        //deklasi dulu connection nya
        //connect()
        //query
        _logger = logger;
    }

    public IActionResult Index()
    {
        //TODO
        List<Barang> barangs = _dbContext.Barangs.ToList();
            
        return View(barangs);
    }
    [HttpPost]
    public IActionResult Create(Barang newBarang){
        
        return View();
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

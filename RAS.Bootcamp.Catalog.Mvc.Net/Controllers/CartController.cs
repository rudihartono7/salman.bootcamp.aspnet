using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Models;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;
    private readonly EMarketDbContext _dbContext;

    public CartController(ILogger<CartController> logger, EMarketDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var keranjang = _dbContext.Keranjangs.ToList();
        return View(keranjang);
    }
    
    [HttpPost]
    public IActionResult AddToCart(int idBarang, int qty){

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult EditCart(int idBarang, int qty){

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int idBarang){

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Clear(){

        return RedirectToAction("Index");
    }
}

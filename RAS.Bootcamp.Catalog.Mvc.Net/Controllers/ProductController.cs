using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Models;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly EMarketDbContext _dbContext;

    public ProductController(ILogger<ProductController> logger, EMarketDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Detail(int id)
    {
        var barang = _dbContext.Barangs.FirstOrDefault(x=>x.Id == id);

        if(barang == null){
            return NotFound();
        }
        
        return View(barang);
    }
}

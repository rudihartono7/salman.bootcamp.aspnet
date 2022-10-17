using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Api.Net.Datas;

namespace RAS.Bootcamp.Api.Net.Controllers;

//sample error message
// Ambiguous HTTP method for action - RAS.Bootcamp.Api.Net.Controllers.ProductController.Get

[ApiController]
[Route("[controller]")]
public class ProductController : Controller {
    private readonly EMarketDbContext _dbContext;
    public ProductController(EMarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Product(){
        var products = _dbContext.Barangs.ToList();

        return Json(products);
    }
}
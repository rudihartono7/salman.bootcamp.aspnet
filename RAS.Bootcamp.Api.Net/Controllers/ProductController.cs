using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Api.Net.Datas;
using RAS.Bootcamp.Api.Net.Datas.Entities;

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

    [HttpGet("{id}")]
    public IActionResult Detail(int id)
    {
        var product = _dbContext.Barangs.FirstOrDefault(x => x.Id == id);

        return Json(product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, RequestBarang request)
    {
        var barang = _dbContext.Barangs
            .FirstOrDefault(y => y.Id == id);
        if (barang == null)
        {
            return NotFound();
        }

        barang.Description = request.Description;
        barang.Harga = request.Harga;
        barang.Kode = request.Kode;
        barang.Nama = request.Nama;
        barang.Stok = request.Stok;
        _dbContext.SaveChanges();
        return Json(barang);
    }


    [HttpPost]
    public IActionResult Create(RequestBarang request)
    {
        var barang = new Barang()
        {
            Description = request.Description,
            Harga = request.Harga,
            Kode = request.Kode,
            IdPenjual = request.IdPenjual,
            Nama = request.Nama,
            Stok = request.Stok
        };
        _dbContext.Barangs.Add(barang);
        _dbContext.SaveChanges();
        return Created("", barang);
    }
}
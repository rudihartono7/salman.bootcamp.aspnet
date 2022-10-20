using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Mvc.Net.Models;
using RAS.Bootcamp.Mvc.Net.Models.Entities;

namespace RAS.Bootcamp.Mvc.Net.Controllers;

[Authorize(Roles = "PENJUAL")]
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

    [HttpGet]
    public IActionResult Create()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult Create(BarangRequest newBarang)
    {
        
        var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

        if(!Directory.Exists(uploadFolder))
            Directory.CreateDirectory(uploadFolder);

        var filename = $"{newBarang.Kode}-{newBarang.FileImage.FileName}";
        var filePath = Path.Combine(uploadFolder,filename);
        
        using var stream = System.IO.File.Create(filePath);
        if(newBarang.FileImage != null)
        {
            newBarang.FileImage.CopyTo(stream);
        }

        var Url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/images/{filename}"; 

        _dbContext.Barangs.Add(new Barang
        {
            Kode = newBarang.Kode,
            Nama = newBarang.Nama,
            Harga = newBarang.Harga,
            Description = newBarang.Description,
            Filename = filename,
            Url = Url
        });




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

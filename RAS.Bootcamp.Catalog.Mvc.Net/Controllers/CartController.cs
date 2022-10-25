using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas.Entities;
using RAS.Bootcamp.Catalog.Mvc.Net.Models;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

[Authorize]
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
        var result = (from a in _dbContext.Keranjangs 
                      join b in _dbContext.Barangs on a.IdBarang equals b.Id
                      select new CartResponse {
                          Id = a.Id,
                          ProductId = a.IdBarang,
                          ProductName = b.Nama,
                          Qty = a.Jumlah,
                          Harga = a.HargaSatuan,
                          ImageUrl = b.Url
                      }).ToList();

        return View(result);
    }
    
    [HttpPost]
    public IActionResult AddToCart(int idBarang, int qty){
        int idUser = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);
        var item = _dbContext.Keranjangs.FirstOrDefault(x=>x.IdBarang == idBarang && x.IdUser == idUser);

        if(item is not null){
            item.Jumlah += qty;

            _dbContext.Update(item);
            _dbContext.SaveChanges();
        }else{
            var barang = _dbContext.Barangs.FirstOrDefault(x=>x.Id == idBarang);

            if(barang == null)
            {
                throw new ArgumentNullException("Barang cannot be found in database");
            }

            var newItem = new Keranjang(){
                IdBarang = idBarang,
                IdUser = idUser,
                Jumlah = qty,
                HargaSatuan = barang.Harga
            };

            _dbContext.Keranjangs.Add(newItem);
            _dbContext.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateCart(int idBarang, int qty){
        
        int idUser = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);

        var item = _dbContext.Keranjangs.FirstOrDefault(x=>x.IdBarang == idBarang && x.IdUser == idUser);

        if(item is null){
            return BadRequest();
        }
        
        item.Jumlah = qty;

        _dbContext.Update(item);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int id){

        var item = _dbContext.Keranjangs.FirstOrDefault(x=>x.Id == id);

        if(item is null){
            return BadRequest();
        }

        _dbContext.Remove(item);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Clear(){
        
        int idUser = int.Parse(User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier).Value);


        var items = _dbContext.Keranjangs.Where(x=>x.IdUser == idUser);
        
        _dbContext.Keranjangs.RemoveRange(items);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }
}

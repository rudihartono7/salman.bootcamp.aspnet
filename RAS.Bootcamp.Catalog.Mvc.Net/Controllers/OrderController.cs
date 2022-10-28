using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAS.Bootcamp.Catalog.Mvc.Net.Datas;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

[Authorize]
public class OrderController : Controller
{
    private readonly EMarketDbContext _dbContext;

    public OrderController(EMarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Yg ditampilkan adalah
    /// 1. Statusnya adalah waiting for payment (menunggu pembayaran)
    /// 2. Statusnya dibayar
    /// 3. Statusnya diproses
    /// 4. Statusnya dikirim
    /// 5. Statusnya completed
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        var userId = User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;
        var id = int.Parse(userId);

        var listOrder = _dbContext.Transaksis
            .Where(e => e.IdUser == id)
            .ToList();

        return View(listOrder);
    }

    public IActionResult Detail(int id)
    {
        var transaksi = _dbContext.Transaksis.FirstOrDefault(e => e.Id == id);
        if (transaksi is null)
            return RedirectToAction("Index");

        var userId = User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;
        var userIdInInt = int.Parse(userId);

        if (transaksi.IdUser != userIdInInt)
            return RedirectToAction("Index");

        return View(transaksi);
    }

    [HttpPost]
    public IActionResult OrderPayment([FromForm] int id)
    {
        var userId = User.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;
        var userIdInInt = int.Parse(userId);

        var transaksi = _dbContext.Transaksis.FirstOrDefault(e => e.Id == id);
        if (transaksi is null)
            return RedirectToAction("Index");

        if (transaksi.IdUser != userIdInInt)
            return RedirectToAction("Index");

        if (transaksi.StatusTransaksi != "WAITINGFORPAYMENT")
            return RedirectToAction("Index");

        transaksi.StatusTransaksi = "PAYED";
        
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Completed()
    {
        return RedirectToAction("Index");
    }
}
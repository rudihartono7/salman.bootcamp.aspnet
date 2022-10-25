using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RAS.Bootcamp.Catalog.Mvc.Net.Controllers;

[Authorize]
public class OrderController : Controller
{
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
        return View();
    }

    public IActionResult Detail(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult OrderPayment()
    {
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Completed()
    {
        return RedirectToAction("Index");
    }
}
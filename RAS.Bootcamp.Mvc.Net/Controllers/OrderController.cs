using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RAS.Bootcamp.Mvc.Net.Controllers;

[Authorize]
public class OrderController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult UpdateStatus()
    {
        return RedirectToAction("Index");
    }
}
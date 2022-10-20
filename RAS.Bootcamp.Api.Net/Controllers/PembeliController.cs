using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Api.Net.Datas;
using RAS.Bootcamp.Api.Net.Datas.Entities;

namespace RAS.Bootcamp.Api.Net.Controllers;

//sample error message
// Ambiguous HTTP method for action - RAS.Bootcamp.Api.Net.Controllers.ProductController.Get

[ApiController]
[Route("[controller]")]
public class PembeliController : Controller {
    private readonly IRepository<Pembely> _repoPembeli;
    public PembeliController(IRepository<Pembely> repository)
    {
        _repoPembeli = repository;
    }
    [HttpGet]
    public IActionResult Get(){
        var datas = _repoPembeli.GetList();
        
        return Json(datas);
    }

    [HttpGet("{id}")]
    public IActionResult Detail(int id)
    {
        var detail = _repoPembeli.Get(id);
        return Json(detail);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, RequestPembeli request)
    {
        var data = _repoPembeli.Get(id);
        if (data == null)
        {
            return NotFound();
        }

        data.NoHp = request.NoHp;
        data.IdUser = request.IdUser;
        data.Alamat = request.Alamat;

        _repoPembeli.Update(data);
        
        return Ok(data);
    }


    [HttpPost]
    public IActionResult Create(RequestPembeli request)
    {
        var data = new Pembely()
        {
            IdUser = request.IdUser,
            Alamat = request.Alamat,
            NoHp = request.NoHp
        };

        _repoPembeli.Add(data);

        return Created("", data);
    }
}
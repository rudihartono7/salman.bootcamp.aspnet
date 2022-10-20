using Microsoft.AspNetCore.Mvc;
using RAS.Bootcamp.Api.Net.Datas;
using RAS.Bootcamp.Api.Net.Datas.Entities;

namespace RAS.Bootcamp.Api.Net.Controllers;

//sample error message
// Ambiguous HTTP method for action - RAS.Bootcamp.Api.Net.Controllers.ProductController.Get

[ApiController]
[Route("[controller]")]
public class DIExploreController : ControllerBase {
    private readonly IRepository<Barang> _repoBarang;
    private readonly IGuidRandom _randomService;
    public DIExploreController(IRepository<Barang> repoBarang, IGuidRandom randomService)
    {
        _repoBarang = repoBarang;
        _randomService = randomService;
    }

    [HttpGet("random-string")]
    public IActionResult RandomString(){

        return Ok(new {
            rndStringInController = _randomService.GetRandomString(),
            rndStringInRepoClass = _repoBarang.GetRandom()
        });
    }
}
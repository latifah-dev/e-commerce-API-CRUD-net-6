using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PembeliController : Controller
{
    private readonly DBPALUGADAContext _dbContext;
    public PembeliController(DBPALUGADAContext dbContext) {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Product() {
        var beli = _dbContext.Pembelis.ToList();
        return Json(beli);
    }
    [HttpPost]
    public IActionResult Create(RequestPembeli beli) {
        var pen = new Pembeli() {
            NamaPembeli = beli.NamaPembeli,
            AlamatPembeli = beli.AlamatPembeli,
            NotelpPembeli = beli.NotelpPembeli,
            NegaraPembeli =  beli.NegaraPembeli,
            IdUser = beli.IdUser,
        };
        _dbContext.Pembelis.Add(pen);
        _dbContext.SaveChanges();
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var jual = _dbContext.Pembelis.FirstOrDefault(x => x.IdPembeli == Id);
        return Json(jual);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestPembeli jual) {
        var pen = _dbContext.Pembelis.FirstOrDefault(x => x.IdPembeli == Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.NamaPembeli = jual.NamaPembeli;
            pen.AlamatPembeli = jual.AlamatPembeli;
            pen.NotelpPembeli = jual.NotelpPembeli;
            pen.NegaraPembeli = jual.NegaraPembeli;
            pen.IdUser = jual.IdUser;
            _dbContext.SaveChanges();
            return Ok();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        var jual = _dbContext.Pembelis.FirstOrDefault(x => x.IdPembeli == Id);
        if (jual == null)
            {
                return NotFound();
            }
        _dbContext.Pembelis.Remove(jual);
        _dbContext.SaveChanges();
        return Json(jual);

    }
}
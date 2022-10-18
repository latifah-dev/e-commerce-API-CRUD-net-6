using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class PenjualController : Controller
{
    private readonly DBPALUGADAContext _dbContext;
    public PenjualController(DBPALUGADAContext dbContext) {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Product() {
        var jual = _dbContext.Penjuals.ToList();
        return Json(jual);
    }
    [HttpPost]
    public IActionResult Create(RequestPenjual jual) {
        var pen = new Penjual() {
            KodeToko = jual.KodeToko,
            NamaToko = jual.NamaToko,
            AlamatToko = jual.AlamatToko,
            IdUser = jual.IdUser,
        };
        _dbContext.Penjuals.Add(pen);
        _dbContext.SaveChanges();
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var jual = _dbContext.Penjuals.FirstOrDefault(x => x.IdPenjual == Id);
        return Json(jual);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestPenjual jual) {
        var pen = _dbContext.Penjuals.FirstOrDefault(x => x.IdPenjual == Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.KodeToko = jual.KodeToko;
            pen.NamaToko = jual.NamaToko;
            pen.AlamatToko = jual.AlamatToko;
            pen.IdUser = jual.IdUser;
            _dbContext.SaveChanges();
            return Ok();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        var jual = _dbContext.Penjuals.FirstOrDefault(x => x.IdPenjual == Id);
        if (jual == null)
            {
                return NotFound();
            }
        _dbContext.Penjuals.Remove(jual);
        _dbContext.SaveChanges();
        return Json(jual);

    }
}
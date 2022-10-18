using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class BarangController : Controller
{
    private readonly DBPALUGADAContext _dbContext;
    public BarangController(DBPALUGADAContext dbContext) {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Product() {
        var Barangs = _dbContext.Barangs.ToList();
        return Json(Barangs);
    }
    [HttpPost]
    public IActionResult Create(RequestBarang bar) {
        var barang = new Barang() {
            KodeBarang = bar.KodeBarang,
            NamaBarang = bar.NamaBarang,
            JenisBarang = bar.JenisBarang,
            HargaBarang = bar.HargaBarang,
            StokBarang = bar.StokBarang,
            DeskripsiBarang = bar.DeskripsiBarang,
            GambarBarang = bar.GambarBarang,
            IdPenjual = bar.IdPenjual,
        };
        _dbContext.Barangs.Add(barang);
        _dbContext.SaveChanges();
        return Created("",barang);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var Barangs = _dbContext.Barangs.FirstOrDefault(x => x.IdBarang == Id);
        return Json(Barangs);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestBarang bar) {
        var Barangs = _dbContext.Barangs.FirstOrDefault(x => x.IdBarang == Id);
            if (Barangs == null)
            {
                return NotFound();
            }
            Barangs.KodeBarang = bar.KodeBarang;
            Barangs.NamaBarang = bar.NamaBarang;
            Barangs.JenisBarang = bar.JenisBarang;
            Barangs.HargaBarang = bar.HargaBarang;
            Barangs.StokBarang = bar.StokBarang;
            Barangs.DeskripsiBarang = bar.DeskripsiBarang;
            Barangs.GambarBarang = bar.GambarBarang;
            Barangs.IdPenjual = bar.IdPenjual;
            _dbContext.SaveChanges();
            return Ok();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        var Barangs = _dbContext.Barangs.FirstOrDefault(x => x.IdBarang == Id);
        if (Barangs == null)
            {
                return NotFound();
            }
        _dbContext.Barangs.Remove(Barangs);
        _dbContext.SaveChanges();
        return Json(Barangs);

    }
}
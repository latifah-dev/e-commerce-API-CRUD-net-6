using Microsoft.AspNetCore.Mvc;
using PALUGADA.API.Datas;
using PALUGADA.API.Datas.Entities;

namespace PALUGADA.API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController : Controller
{
    private readonly DBPALUGADAContext _dbContext;
    public UserController(DBPALUGADAContext dbContext) {
        _dbContext = dbContext;
    }
    [HttpGet]
    public IActionResult Product() {
        var jual = _dbContext.Users.ToList();
        return Json(jual);
    }
    [HttpPost]
    public IActionResult Create(RequestUser jual) {
        var pen = new User() {
            Username = jual.Username,
            Password = jual.Password,
            NohpUser = jual.NohpUser,
            TipeUser = jual.TipeUser,
            EmailUser = jual.EmailUser,
        };
        _dbContext.Users.Add(pen);
        _dbContext.SaveChanges();
        return Created("",pen);
    }

    [HttpGet("{Id}")]
    public IActionResult Detail(int Id) {
        var jual = _dbContext.Users.FirstOrDefault(x => x.IdUser == Id);
        return Json(jual);
    }
    [HttpPut("{Id}")]
    public IActionResult Update(int Id, RequestUser jual) {
        var pen = _dbContext.Users.FirstOrDefault(x => x.IdUser == Id);
            if (pen == null)
            {
                return NotFound();
            }
            pen.Username = jual.Username;
            pen.Password = jual.Password;
            pen.NohpUser = jual.NohpUser;
            pen.TipeUser = jual.TipeUser;
            pen.EmailUser = jual.EmailUser;
            _dbContext.SaveChanges();
            return Ok();
    }

    [HttpDelete("{Id}")]
    public IActionResult Delete(int Id) {
        var jual = _dbContext.Users.FirstOrDefault(x => x.IdUser == Id);
        if (jual == null)
            {
                return NotFound();
            }
        _dbContext.Users.Remove(jual);
        _dbContext.SaveChanges();
        return Json(jual);

    }
}
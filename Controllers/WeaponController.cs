using Microsoft.AspNetCore.Mvc;

using CRUDSmith.Models;
using CRUDSmith.Repositories;


namespace CRUDSmith.Controllers
{
  [ApiController]
  [Route("api/weapon")]
  public class WeaponController : ControllerBase
  {
    private readonly IWeaponRepository repository;

    public WeaponController(IWeaponRepository repository)
    {
      this.repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> AddWeapon(Weapon weapon)
    {
      this.repository.addWeapon(weapon);

      return await this.repository.SaveChangesAsync()
        ? Ok(weapon)
        : BadRequest("Wrong parameters");
    }

    [HttpGet]
    public async Task<IActionResult> GetWeapons()
    {
      var weapons = await this.repository.GetWeapons();

      return weapons.Any()
        ? Ok(weapons)
        : BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeapon(int id)
    {
      var weapons = await this.repository.GetWeapon(id);

      return weapons != null
        ? Ok(weapons)
        : NotFound("Weapon not found");
    }
  }
}
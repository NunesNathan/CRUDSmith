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

    [HttpGet]
    public async Task<IActionResult> GetWeapons()
    {
      var weapons = await this.repository.GetWeapons();

      return weapons.Any()
        ? Ok(weapons)
        : BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> AddWeapon(Weapon weapon)
    {
      this.repository.addWeapon(weapon);

      return await this.repository.SaveChangesAsync()
        ? Ok(weapon.Id)
        : BadRequest();

    }
  }
}
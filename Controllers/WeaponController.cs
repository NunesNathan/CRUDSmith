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
      var weapon = await this.repository.GetWeapon(id);

      return weapon != null
        ? Ok(weapon)
        : NotFound("Weapon not found");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateWeapon(int id, Weapon weapon)
    {
      var gw = await this.repository.GetWeapon(id);

      if (gw == null) return NotFound("Weapon not found");

      gw.Name = weapon.Name ?? gw.Name;
      gw.BaseDamage = weapon.BaseDamage != gw.BaseDamage ? gw.BaseDamage : weapon.BaseDamage;
      gw.BonusDamage = weapon.BonusDamage != gw.BonusDamage ? gw.BonusDamage : weapon.BonusDamage;
      gw.BonusDamegeType = weapon.BonusDamegeType ?? gw.BonusDamegeType;
      gw.SlotToUse = weapon.SlotToUse ?? gw.SlotToUse;
      gw.SpecialBonusGiven = weapon.SpecialBonusGiven ?? gw.SpecialBonusGiven;

      return await this.repository.SaveChangesAsync()
        ? Ok(gw)
        : BadRequest("Wrong parameters");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> removeWeapon(int id)
    {
      this.repository.removeWeapon(id);

      return await this.repository.SaveChangesAsync()
        ? NoContent()
        : NotFound("Weapon not found");
    }
  }
}
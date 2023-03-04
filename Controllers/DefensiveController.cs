using Microsoft.AspNetCore.Mvc;

using CRUDSmith.Models;
using CRUDSmith.Repositories;


namespace CRUDSmith.Controllers
{
  [ApiController]
  [Route("api/defensive")]

  public class DefensiveController : ControllerBase
  {
    private readonly IDefensiveRepository repository;

    public DefensiveController(IDefensiveRepository repository)
    {
      this.repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> AddDefensive(Defensive defensive)
    {
      this.repository.addDefensive(defensive);

      return await this.repository.SaveChangesAsync()
        ? Ok(defensive)
        : BadRequest("Wrong parameters");
    }

    [HttpGet]
    public async Task<IActionResult> GetDefensives()
    {
      var defensives = await this.repository.GetDefensives();

      return defensives.Any()
        ? Ok(defensives)
        : BadRequest();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDefensive(int id)
    {
      var defensive = await this.repository.GetDefensive(id);

      return defensive != null
        ? Ok(defensive)
        : NotFound("Defensive not found");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> updateDefensive(int id, Defensive defensive)
    {
      var gd = await this.repository.GetDefensive(id);

      if (gd == null) return NotFound("Defensive not found");

      gd.Name = defensive.Name ?? gd.Name;
      gd.DefensiveBonus = defensive.DefensiveBonus != gd.DefensiveBonus ? gd.DefensiveBonus : defensive.DefensiveBonus;
      gd.RequiredStrength = defensive.RequiredStrength != gd.RequiredStrength ? gd.RequiredStrength : defensive.RequiredStrength;
      gd.SlotToUse = defensive.SlotToUse ?? gd.SlotToUse;
      gd.SpecialBonusGiven = defensive.SpecialBonusGiven ?? gd.SpecialBonusGiven;

      return await this.repository.SaveChangesAsync()
        ? Ok(gd)
        : BadRequest("Wrong parameters");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> removeDefensive(int id)
    {
      this.repository.removeDefensive(id);

      return await this.repository.SaveChangesAsync()
        ? NoContent()
        : NotFound("Defensive not found");
    }
  }
}
using Microsoft.EntityFrameworkCore;

using CRUDSmith.Models;
using CRUDSmith.Data;

namespace CRUDSmith.Repositories
{
  public class WeaponRepository : IWeaponRepository
  {
    private readonly WeaponDbContext ctx;

    public WeaponRepository(WeaponDbContext ctx)
    {
      this.ctx = ctx;
    }

    public async void addWeapon(Weapon weapon)
    {
      await this.ctx.weapons.AddAsync(weapon);
    }

    public async Task<Weapon> GetWeapon(int id)
    {
      return await this.ctx.weapons
        .Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Weapon>> GetWeapons()
    {
      return await this.ctx.weapons.ToListAsync();
    }

    public async void removeWeapon(int id)
    {
      var weapon = this.ctx.weapons.Where(x => x.Id == id).Single();

      this.ctx.weapons.Remove(weapon);
    }
    public void updateWeapon(int id, Weapon weapon)
    {
      this.ctx.weapons.Update(weapon);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await ctx.SaveChangesAsync() > 0;
    }
  }
}
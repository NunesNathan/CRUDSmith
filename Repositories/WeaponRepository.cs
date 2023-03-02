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

    public void removeWeapon(int id)
    {
      throw new NotImplementedException();
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
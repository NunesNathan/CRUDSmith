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

    public Task<Weapon> GetWeapon(int id)
    {
      throw new NotImplementedException();
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
      throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await ctx.SaveChangesAsync() > 0;
    }
  }
}
using Microsoft.EntityFrameworkCore;

using CRUDSmith.Models;
using CRUDSmith.Data;


namespace CRUDSmith.Repositories
{
    public class DefensiveRepository : IDefensiveRepository
    {
    private readonly DataDbContext ctx;

    public DefensiveRepository(DataDbContext ctx)
    {
        this.ctx = ctx;
    }

    public async void addDefensive(Defensive defensive)
    {
      await this.ctx.defensives.AddAsync(defensive);
    }

    public async Task<Defensive> GetDefensive(int id)
    {
      return await this.ctx.defensives
        .Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Defensive>> GetDefensives()
    {
      return await this.ctx.defensives.ToListAsync();
    }

    public async void removeDefensive(int id)
    {
      var defensive = this.ctx.defensives.Where(x => x.Id == id).Single();

      this.ctx.defensives.Remove(defensive);
    }
    public void updateDefensive(int id, Defensive defensive)
    {
      this.ctx.defensives.Update(defensive);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return await ctx.SaveChangesAsync() > 0;
    }
  }
}
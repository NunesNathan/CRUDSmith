using CRUDSmith.Models;


namespace CRUDSmith.Repositories
{
  public interface IDefensiveRepository
  {
    Task<IEnumerable<Defensive>> GetDefensives();
    Task<Defensive> GetDefensive(int id);
    void addDefensive(Defensive defensive);
    void updateDefensive(int id, Defensive defensive);
    void removeDefensive(int id);

    Task<bool> SaveChangesAsync();
  }
}
using CRUDSmith.Models;

namespace CRUDSmith.Repositories
{
  public interface IWeaponRepository
  {
    Task<IEnumerable<Weapon>> GetWeapons();
    Task<Weapon> GetWeapon(int id);
    void addWeapon(Weapon weapon);
    void updateWeapon(int id, Weapon weapon);
    void removeWeapon(int id);

    Task<bool> SaveChangesAsync();
  }
}
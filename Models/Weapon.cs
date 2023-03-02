namespace CRUDSmith.Models
{
  public class Weapon : Equipment
    {
        public int BaseDamage { get; set; }
        public string BonusDamegeType { get; set; }
        public int BonusDamage { get; set; }
    }
}   
namespace CRUDSmith.Models
{
  public abstract class Equipment
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SpecialBonusGiven { get; set; }
    public string SlotToUse { get; set; }

    public DateTime CreatedAt { get; set; }
  }
}
using Microsoft.EntityFrameworkCore;

using CRUDSmith.Models;


namespace CRUDSmith.Data
{
  public class WeaponDbContext : DbContext
  {
    public WeaponDbContext(DbContextOptions<WeaponDbContext> options) : base(options)
    {
    }

    public DbSet<Weapon> weapons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var model = modelBuilder.Entity<Weapon>();
      model.ToTable("weapons");
      model.HasKey(x => x.Id);
      model.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
      model.Property(x => x.SlotToUse).HasColumnName("slot_to_use").IsRequired();
      model.Property(x => x.BaseDamage).HasColumnName("base_damage").IsRequired();
      model.Property(x => x.BonusDamage).HasColumnName("bonus_damage").IsRequired();
      model.Property(x => x.BonusDamegeType).HasColumnName("bonus_damage_type").IsRequired();
      model.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
      model.Property(x => x.SpecialBonusGiven).HasColumnName("special_bonus_given").IsRequired();
    }
  }
}
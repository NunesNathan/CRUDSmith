using Microsoft.EntityFrameworkCore;

using CRUDSmith.Models;


namespace CRUDSmith.Data
{
  public class DataDbContext : DbContext
  {
    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    public DbSet<Weapon> weapons { get; set; }
    public DbSet<Defensive> defensives { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      var weaponModel = modelBuilder.Entity<Weapon>();
      weaponModel.ToTable("weapons");
      weaponModel.HasKey(x => x.Id);
      weaponModel.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
      weaponModel.Property(x => x.SlotToUse).HasColumnName("slot_to_use").IsRequired();
      weaponModel.Property(x => x.BaseDamage).HasColumnName("base_damage").IsRequired();
      weaponModel.Property(x => x.BonusDamage).HasColumnName("bonus_damage").IsRequired();
      weaponModel.Property(x => x.BonusDamegeType).HasColumnName("bonus_damage_type").IsRequired();
      weaponModel.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
      weaponModel.Property(x => x.SpecialBonusGiven).HasColumnName("special_bonus_given").IsRequired();

      var defensiveModel = modelBuilder.Entity<Defensive>();
      defensiveModel.ToTable("defensives");
      defensiveModel.HasKey(x => x.Id);
      defensiveModel.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
      defensiveModel.Property(x => x.SlotToUse).HasColumnName("slot_to_use").IsRequired();
      defensiveModel.Property(x => x.DefensiveBonus).HasColumnName("base_damage").IsRequired();
      defensiveModel.Property(x => x.RequiredStrength).HasColumnName("bonus_damage").IsRequired();
      defensiveModel.Property(x => x.CreatedAt).HasColumnName("created_at").HasDefaultValueSql("NOW()");
      defensiveModel.Property(x => x.SpecialBonusGiven).HasColumnName("special_bonus_given").IsRequired();
    }
  }
}
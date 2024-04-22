using Data.Enums;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class NinjaContext : DbContext
{
    public NinjaContext(DbContextOptions<NinjaContext> options) : base(options)
    {
    }

    public DbSet<Ninja> Ninjas { get; set; }
    public DbSet<Gear> Gear { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NinjaGear>()
            .HasKey(n => new { n.NinjaId, n.GearId });

        modelBuilder.Entity<NinjaGear>()
            .HasOne(n => n.Ninja)
            .WithMany(n => n.NinjaGear)
            .HasForeignKey(n => n.NinjaId);

        modelBuilder.Entity<NinjaGear>()
            .HasOne(n => n.Gear)
            .WithMany(n => n.NinjaGear)
            .HasForeignKey(n => n.GearId);

        modelBuilder.Entity<Transaction>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Transaction>()
            .Property(e => e.NinjaId)
            .IsRequired(false);
        
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Ninja)
            .WithMany(n => n.Transactions)
            .HasForeignKey(t => t.NinjaId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Ninja>().HasData(
            new Ninja
            {
                Id = 1,
                Name = "Sensei",
                Gold = 120
            },
            new Ninja
            {
                Id = 2,
                Name = "Naruto",
                Gold = 100
            },
            new Ninja
            {
                Id = 3,
                Name = "Sasuke",
                Gold = 100
            },
            new Ninja
            {
                Id = 4,
                Name = "Sakura",
                Gold = 100
            }
        );

        modelBuilder.Entity<Gear>().HasData(
            new Gear
            {
                Id = 1,
                Name = "Gold Helmet",
                Price = 70,
                Strength = 15,
                Agility = 5,
                Intelligence = 2,
                Category = GearCategory.Head
            },
            new Gear
            {
                Id = 2,
                Name = "Iron Helmet",
                Price = 150,
                Strength = 20,
                Agility = 10,
                Intelligence = 12,
                Category = GearCategory.Head
            },
            new Gear
            {
                Id = 3,
                Name = "Diamond Helmet",
                Price = 220,
                Strength = 30,
                Agility = 15,
                Intelligence = 16,
                Category = GearCategory.Head
            },
            new Gear
            {
                Id = 4,
                Name = "Gold Chestplate",
                Price = 150,
                Strength = 3,
                Agility = 2,
                Intelligence = 1,
                Category = GearCategory.Chest
            },
            new Gear
            {
                Id = 5,
                Name = "Iron Chestplate",
                Price = 225,
                Strength = 9,
                Agility = 16,
                Intelligence = 20,
                Category = GearCategory.Chest
            },
            new Gear
            {
                Id = 6,
                Name = "Diamond Chestplate",
                Price = 275,
                Strength = 15,
                Agility = 5,
                Intelligence = 8,
                Category = GearCategory.Chest
            },
            new Gear
            {
                Id = 7,
                Name = "Gold Sword",
                Price = 150,
                Strength = 18,
                Agility = 14,
                Intelligence = 13,
                Category = GearCategory.Hand
            },
            new Gear
            {
                Id = 8,
                Name = "Iron Sword",
                Price = 205,
                Strength = 25,
                Agility = 18,
                Intelligence = 16,
                Category = GearCategory.Hand
            },
            new Gear
            {
                Id = 9,
                Name = "Diamond Sword",
                Price = 265,
                Strength = 31,
                Agility = 23,
                Intelligence = 20,
                Category = GearCategory.Hand
            },
            new Gear
            {
                Id = 10,
                Name = "Gold Boots",
                Price = 60,
                Strength = 6,
                Agility = 5,
                Intelligence = 3,
                Category = GearCategory.Feet
            },
            new Gear
            {
                Id = 11,
                Name = "Iron Boots",
                Price = 100,
                Strength = 12,
                Agility = 10,
                Intelligence = 6,
                Category = GearCategory.Feet
            },
            new Gear
            {
                Id = 12,
                Name = "Diamond Boots",
                Price = 120,
                Strength = 16,
                Agility = 7,
                Intelligence = 8,
                Category = GearCategory.Feet
            },
            new Gear
            {
                Id = 13,
                Name = "Gold Ring",
                Price = 40,
                Strength = 2,
                Agility = 3,
                Intelligence = 1,
                Category = GearCategory.Ring
            },
            new Gear
            {
                Id = 14,
                Name = "Iron Ring",
                Price = 60,
                Strength = 6,
                Agility = 4,
                Intelligence = 2,
                Category = GearCategory.Ring
            },
            new Gear
            {
                Id = 15,
                Name = "Diamond Ring",
                Price = 80,
                Strength = 9,
                Agility = 5,
                Intelligence = 4,
                Category = GearCategory.Ring
            },
            new Gear
            {
                Id = 16,
                Name = "Gold Necklace",
                Price = 25,
                Strength = 11,
                Agility = 10,
                Intelligence = 1,
                Category = GearCategory.Necklace
            },
            new Gear
            {
                Id = 17,
                Name = "Iron Necklace",
                Price = 50,
                Strength = 18,
                Agility = 20,
                Intelligence = 8,
                Category = GearCategory.Necklace
            },
            new Gear
            {
                Id = 18,
                Name = "Diamond Necklace",
                Price = 75,
                Strength = 24,
                Agility = 30,
                Intelligence = 24,
                Category = GearCategory.Necklace
            }
        );
    }
}
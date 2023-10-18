using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SipBiteUnite.Models;

public partial class SipByteDatabaseContext : DbContext
{
    public SipByteDatabaseContext()
    {
    }

    public SipByteDatabaseContext(DbContextOptions<SipByteDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Beer> Beers { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    public virtual DbSet<Shopssum> Shopssums { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=127.0.0.1;Database=SipByteDatabase;Username=postgres;Password=admin");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Beer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("beer_pkey");

            entity.ToTable("beer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Producer)
                .HasMaxLength(255)
                .HasColumnName("producer");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_pkey");

            entity.ToTable("food");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("category");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rating_pkey");

            entity.ToTable("rating");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBeer).HasColumnName("id_beer");
            entity.Property(e => e.IdFood).HasColumnName("id_food");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Rating1).HasColumnName("rating");

            entity.HasOne(d => d.IdBeerNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdBeer)
                .HasConstraintName("rating_id_beer_fkey");

            entity.HasOne(d => d.IdFoodNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdFood)
                .HasConstraintName("rating_id_food_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("rating_id_user_fkey");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("shops_pkey");

            entity.ToTable("shops");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Shopssum>(entity =>
        {
            entity.HasKey(e => new { e.ShopId, e.BeerId }).HasName("shopssum_pkey");

            entity.ToTable("shopssum");

            entity.Property(e => e.ShopId).HasColumnName("shop_id");
            entity.Property(e => e.BeerId).HasColumnName("beer_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Beer).WithMany(p => p.Shopssums)
                .HasForeignKey(d => d.BeerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shopssum_beer_id_fkey");

            entity.HasOne(d => d.Shop).WithMany(p => p.Shopssums)
                .HasForeignKey(d => d.ShopId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("shopssum_shop_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IsLogined).HasColumnName("is_logined");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

using System;
using System.Collections.Generic;
using ConsoleApp.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Context;

public partial class ProductCatalog : DbContext
{
    public ProductCatalog()
    {
    }

    public ProductCatalog(DbContextOptions<ProductCatalog> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriesEntity> CategoriesEntities { get; set; }

    public virtual DbSet<ClientsEntity> ClientsEntities { get; set; }

    public virtual DbSet<DirectionsEntity> DirectionsEntities { get; set; }

    public virtual DbSet<ProductsEntity> ProductsEntities { get; set; }

    public virtual DbSet<ReadersEntity> ReadersEntities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lears\\source\\repos\\lear23\\TaskGvApproved\\AllForApproved\\Data\\ProductDataBase.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriesEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC073CEF2D12");

            entity.ToTable("CategoriesEntity");
        });

        modelBuilder.Entity<ClientsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientsE__3214EC07C3EBC9D8");

            entity.ToTable("ClientsEntity");

            entity.HasOne(d => d.Direction).WithMany(p => p.ClientsEntities)
                .HasForeignKey(d => d.DirectionId)
                .HasConstraintName("FK__ClientsEn__Direc__1CBC4616");

            entity.HasOne(d => d.Reader).WithMany(p => p.ClientsEntities)
                .HasForeignKey(d => d.ReaderId)
                .HasConstraintName("FK__ClientsEn__Reade__1BC821DD");
        });

        modelBuilder.Entity<DirectionsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Directio__3214EC0799EA987C");

            entity.ToTable("DirectionsEntity");
        });

        modelBuilder.Entity<ProductsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07FEB050F1");

            entity.ToTable("ProductsEntity");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsEntities)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ProductsE__Categ__1F98B2C1");
        });

        modelBuilder.Entity<ReadersEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReadersE__3214EC074E9A6DE5");

            entity.ToTable("ReadersEntity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

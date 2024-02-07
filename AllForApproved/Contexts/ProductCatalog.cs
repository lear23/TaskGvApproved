using System;
using System.Collections.Generic;
using AllForApproved.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace AllForApproved.Contexts
{
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07B76D58F9");
                entity.ToTable("CategoriesEntity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Cambio aquí
            });

            modelBuilder.Entity<ClientsEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ClientsE__3214EC0794C505EB");
                entity.ToTable("ClientsEntity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Cambio aquí

                entity.HasOne(d => d.Direction).WithMany(p => p.ClientsEntities)
                    .HasForeignKey(d => d.DirectionId)
                    .HasConstraintName("FK__ClientsEn__Direc__09A971A2");

                entity.HasOne(d => d.Reader).WithMany(p => p.ClientsEntities)
                    .HasForeignKey(d => d.ReaderId)
                    .HasConstraintName("FK__ClientsEn__Reade__08B54D69");
            });

            modelBuilder.Entity<DirectionsEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Directio__3214EC075A034F8D");
                entity.ToTable("DirectionsEntity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Cambio aquí
            });

            modelBuilder.Entity<ProductsEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC079BB7ABA7");
                entity.ToTable("ProductsEntity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Cambio aquí

                entity.HasOne(d => d.Category).WithMany(p => p.ProductsEntities)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ProductsE__Categ__0C85DE4D");
            });

            modelBuilder.Entity<ReadersEntity>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ReadersE__3214EC070667AA4B");
                entity.ToTable("ReadersEntity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); // Cambio aquí
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}






//using System;
//using System.Collections.Generic;
//using AllForApproved.ProductEntities;
//using Microsoft.EntityFrameworkCore;

//namespace AllForApproved.Contexts;

//public partial class ProductCatalog : DbContext
//{
//    public ProductCatalog()
//    {
//    }

//    public ProductCatalog(DbContextOptions<ProductCatalog> options)
//        : base(options)
//    {
//    }

//    public virtual DbSet<CategoriesEntity> CategoriesEntities { get; set; }

//    public virtual DbSet<ClientsEntity> ClientsEntities { get; set; }

//    public virtual DbSet<DirectionsEntity> DirectionsEntities { get; set; }

//    public virtual DbSet<ProductsEntity> ProductsEntities { get; set; }

//    public virtual DbSet<ReadersEntity> ReadersEntities { get; set; }

//    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//    //        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\lears\\source\\repos\\lear23\\TaskGvApproved\\AllForApproved\\Data\\ProductDataBase.mdf;Integrated Security=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<CategoriesEntity>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07B76D58F9");

//            entity.ToTable("CategoriesEntity");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//        });

//        modelBuilder.Entity<ClientsEntity>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ClientsE__3214EC0794C505EB");

//            entity.ToTable("ClientsEntity");

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Direction).WithMany(p => p.ClientsEntities)
//                .HasForeignKey(d => d.DirectionId)
//                .HasConstraintName("FK__ClientsEn__Direc__09A971A2");

//            entity.HasOne(d => d.Reader).WithMany(p => p.ClientsEntities)
//                .HasForeignKey(d => d.ReaderId)
//                .HasConstraintName("FK__ClientsEn__Reade__08B54D69");
//        });

//        modelBuilder.Entity<DirectionsEntity>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Directio__3214EC075A034F8D");

//            entity.ToTable("DirectionsEntity");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//        });

//        modelBuilder.Entity<ProductsEntity>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC079BB7ABA7");

//            entity.ToTable("ProductsEntity");

//            entity.Property(e => e.Id).ValueGeneratedNever();

//            entity.HasOne(d => d.Category).WithMany(p => p.ProductsEntities)
//                .HasForeignKey(d => d.CategoryId)
//                .HasConstraintName("FK__ProductsE__Categ__0C85DE4D");
//        });

//        modelBuilder.Entity<ReadersEntity>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__ReadersE__3214EC070667AA4B");

//            entity.ToTable("ReadersEntity");

//            entity.Property(e => e.Id).ValueGeneratedNever();
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//}

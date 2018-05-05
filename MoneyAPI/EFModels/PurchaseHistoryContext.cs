using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MoneyAPI.EFModels
{
    public partial class PurchaseHistoryContext : DbContext
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<PurchaseBank> PurchaseBank { get; set; }
        public virtual DbSet<PurchaseNames> PurchaseNames { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public PurchaseHistoryContext(DbContextOptions<PurchaseHistoryContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("Categories", "purchase");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PurchaseBank>(entity =>
            {
                entity.ToTable("PurchaseBank", "purchase");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Categorycolumn).HasColumnName("categorycolumn");

                entity.Property(e => e.Datecolumn).HasColumnName("datecolumn");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Namecolumn).HasColumnName("namecolumn");

                entity.Property(e => e.Valuecolumn).HasColumnName("valuecolumn");
            });

            modelBuilder.Entity<PurchaseNames>(entity =>
            {
                entity.ToTable("PurchaseNames", "purchase");

                entity.HasIndex(e => e.Category)
                    .HasName("nc_PurchaseNamesFKCategory");

                entity.HasIndex(e => e.Purchasetype)
                    .HasName("nc_PurchaseNamesFKType");

                entity.HasIndex(e => new { e.Name, e.Purchasetype, e.Category })
                    .HasName("PK_UniquePurchaseNamePerTypeANDCategory")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Purchasetype).HasColumnName("purchasetype");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.PurchaseNames)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_Category");

                entity.HasOne(d => d.PurchasetypeNavigation)
                    .WithMany(p => p.PurchaseNames)
                    .HasForeignKey(d => d.Purchasetype)
                    .HasConstraintName("FK_Type");
            });

            modelBuilder.Entity<Purchases>(entity =>
            {
                entity.ToTable("Purchases", "purchase");

                entity.HasIndex(e => e.Purchasename)
                    .HasName("nc_PurchasesFKPurchaseName");

                entity.HasIndex(e => e.Username)
                    .HasName("Non-Clustered_Username");

                entity.HasIndex(e => new { e.Id, e.Purchasedate, e.Amount })
                    .HasName("nc_testAmount");

                entity.HasIndex(e => new { e.Purchasename, e.Purchasedate, e.Amount, e.Username })
                    .HasName("PK_UniquePurchaseNamePerDateAmount")
                    .IsUnique();

                entity.HasIndex(e => new { e.Username, e.Purchasename, e.Amount, e.Purchasedate })
                    .HasName("NC_performancetest");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Insertiondate)
                    .HasColumnName("insertiondate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Purchasedate)
                    .HasColumnName("purchasedate")
                    .HasColumnType("date");

                entity.Property(e => e.Purchasename).HasColumnName("purchasename");

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.PurchasenameNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.Purchasename)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseName");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserName");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "purchase");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });
        }
    }
}

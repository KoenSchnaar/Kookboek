using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KookboekDB
{
    public partial class KookboekContext : DbContext
    {
        public KookboekContext()
        {
        }

        public KookboekContext(DbContextOptions<KookboekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GerechtIngrediënt> GerechtIngrediënts { get; set; }
        public virtual DbSet<Gerechten> Gerechtens { get; set; }
        public virtual DbSet<Ingrediënten> Ingrediëntens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-ODASLGV9\\MSSQLSERVER01;Initial Catalog=Kookboek;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<GerechtIngrediënt>(entity =>
            {
                entity.ToTable("GerechtIngrediënt");

                entity.Property(e => e.GerechtIngrediëntId).HasColumnName("GerechtIngrediënt_ID");

                entity.Property(e => e.Eenheid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GerechtId).HasColumnName("Gerecht_ID");

                entity.Property(e => e.Hoeveelheid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IngrediëntId).HasColumnName("Ingrediënt_ID");
            });

            modelBuilder.Entity<Gerechten>(entity =>
            {
                entity.HasKey(e => e.GerechtId)
                    .HasName("PK__Gerechte__41D8F4D761B7583F");

                entity.ToTable("Gerechten");

                entity.Property(e => e.GerechtId).HasColumnName("Gerecht_ID");

                entity.Property(e => e.AantalIngrediënten).HasColumnName("Aantal_Ingrediënten");

                entity.Property(e => e.Beschrijving)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gerecht)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ingrediënten>(entity =>
            {
                entity.HasKey(e => e.IngrediëntId)
                    .HasName("PK__Ingredië__FB68AE4D5F2BEDAE");

                entity.ToTable("Ingrediënten");

                entity.Property(e => e.IngrediëntId).HasColumnName("Ingrediënt_ID");

                entity.Property(e => e.Ingrediënt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
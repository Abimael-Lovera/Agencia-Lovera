using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lovera.Models
{
    public partial class AgenciaContext : DbContext
    {
        public AgenciaContext()
        {
        }

        public AgenciaContext(DbContextOptions<AgenciaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Destino> Destinos { get; set; } = null!;
        public virtual DbSet<Pacote> Pacotes { get; set; } = null!;
        public virtual DbSet<Promo> Promos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-660U0M0;Initial Catalog=Agencia;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compra__C4BAA60438D9D522");

                entity.ToTable("Compra");

                entity.Property(e => e.IdCompra).HasColumnName("id_compra");

                entity.Property(e => e.IdPacote).HasColumnName("id_pacote");

                entity.Property(e => e.IdPromo).HasColumnName("id_promo");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdPacoteNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdPacote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_fk1");

                entity.HasOne(d => d.IdPromoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdPromo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_fk2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Compra_fk0");
            });

            modelBuilder.Entity<Destino>(entity =>
            {
                entity.HasKey(e => e.IdDestino)
                    .HasName("PK__Destinos__F1DC09EA30F1EAEA");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.Descripcao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("descripcao");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Pacote>(entity =>
            {
                entity.HasKey(e => e.IdPacote)
                    .HasName("PK__Pacotes__0B58B326F5715961");

                entity.Property(e => e.IdPacote).HasColumnName("id_pacote");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("preco");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Pacotes)
                    .HasForeignKey(d => d.IdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Pacotes_fk0");
            });

            modelBuilder.Entity<Promo>(entity =>
            {
                entity.HasKey(e => e.IdPromo)
                    .HasName("PK__Promo__DFB74B64E8A25E3D");

                entity.ToTable("Promo");

                entity.Property(e => e.IdPromo).HasColumnName("id_promo");

                entity.Property(e => e.Descripcao)
                    .HasColumnType("text")
                    .HasColumnName("descripcao");

                entity.Property(e => e.IdDestino).HasColumnName("id_destino");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("preco");

                entity.HasOne(d => d.IdDestinoNavigation)
                    .WithMany(p => p.Promos)
                    .HasForeignKey(d => d.IdDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Promo_fk0");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Usuario__D2D1463783505304");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D1053428CA454C")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__Usuario__C1F897317B2286A3")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cidade");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CPF")
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

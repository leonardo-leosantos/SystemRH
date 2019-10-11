using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SystemRH.Models
{
    public partial class SYSTEMRHContext : DbContext
    {
        public SYSTEMRHContext()
        {
        }

        public SYSTEMRHContext(DbContextOptions<SYSTEMRHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCargo> TbCargo { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            //To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=10.39.0.23;Initial Catalog=SYSTEMRH;Persist Security Info=True;User ID=sa;Password=dfp3@PM");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<TbCargo>(entity =>
            {
                entity.ToTable("TB_CARGO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.ToTable("TB_FUNCIONARIO");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cargoid).HasColumnName("cargoid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .HasColumnName("salario")
                    .HasColumnType("decimal(6, 2)");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.TbFuncionario)
                    .HasForeignKey(d => d.Cargoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_funcionario_cargo");
            });
        }
    }
}

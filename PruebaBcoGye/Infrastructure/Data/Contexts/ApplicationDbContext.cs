using Microsoft.EntityFrameworkCore;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Infrastructure.tmp;

namespace Infrastructure.Data.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-4AJ6HNBS\\HENRY; initial catalog=db_prueba; user id=sa; Password=1234; MultipleActiveResultSets=true;TrustServerCertificate=True");
        }

        public virtual DbSet<UsuarioVendedor> UsuarioVendedor { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioVendedor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Usuario");

                entity.ToTable("UsuarioVendedor");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DocumentoIdentidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Estado).HasDefaultValue((short)1);
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Clientes");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Direccion)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.Property(e => e.DocumentoIdentidad)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.Estado).HasDefaultValue((short)1);
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Nombres)
                    .HasMaxLength(150)
                    .IsUnicode(false);
                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07F62385B8");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Estado).HasDefaultValue((short)1);
                entity.Property(e => e.FechaModificacion)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.Precio).HasColumnType("decimal(10, 4)");
            });

        }
    }
}

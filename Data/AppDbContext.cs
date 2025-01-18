using Microsoft.EntityFrameworkCore;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId);
        });
}

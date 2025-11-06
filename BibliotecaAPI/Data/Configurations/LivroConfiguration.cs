using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaAPI.Data.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livros");
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Titulo).IsRequired().HasMaxLength(200);
        builder.Property(l => l.Autor).IsRequired().HasMaxLength(150);
        builder.Property(l => l.Isbn).HasMaxLength(20);
        builder.Property(l => l.Disponivel).HasDefaultValue(true);

        builder.HasMany(l => l.Emprestimos)
               .WithOne(e => e.Livro!)
               .HasForeignKey(e => e.LivroId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
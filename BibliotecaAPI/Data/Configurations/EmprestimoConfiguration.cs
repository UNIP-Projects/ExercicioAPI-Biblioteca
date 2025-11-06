using BibliotecaAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaAPI.Data.Configurations;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> builder)
    {
        builder.ToTable("Emprestimos");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DataEmprestimo).IsRequired();
        builder.Property(e => e.DataPrevistaDevolucao).IsRequired();
        builder.Property(e => e.Status).HasConversion<int>();

        builder.HasOne(e => e.Livro)
               .WithMany(l => l.Emprestimos)
               .HasForeignKey(e => e.LivroId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Usuario)
               .WithMany(u => u.Emprestimos)
               .HasForeignKey(e => e.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
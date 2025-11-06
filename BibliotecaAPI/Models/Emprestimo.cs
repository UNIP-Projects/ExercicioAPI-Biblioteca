namespace BibliotecaAPI.Models;

public class Emprestimo
{
    public int Id { get; set; }

    public int LivroId { get; set; }
    public Livro? Livro { get; set; }

    public int UsuarioId { get; set; }
    public Usuario? Usuario { get; set; }

    public DateTime DataEmprestimo { get; set; } = DateTime.UtcNow;
    public DateTime DataPrevistaDevolucao { get; set; }
    public DateTime? DataDevolucao { get; set; }

    public StatusEmprestimo Status { get; set; } = StatusEmprestimo.Ativo;
}
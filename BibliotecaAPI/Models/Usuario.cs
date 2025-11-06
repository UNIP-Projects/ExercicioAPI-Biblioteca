using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [MaxLength(120)]
    public string Nome { get; set; } = string.Empty;

    public TipoUsuario Tipo { get; set; } = TipoUsuario.Aluno;

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
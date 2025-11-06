using System.ComponentModel.DataAnnotations;

namespace BibliotecaAPI.Models;

public class Livro
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Autor { get; set; } = string.Empty;

    [MaxLength(20)]
    public string Isbn { get; set; } = string.Empty;

    public bool Disponivel { get; set; } = true;

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public ICollection<Emprestimo> Emprestimos { get; set; } = new List<Emprestimo>();
}
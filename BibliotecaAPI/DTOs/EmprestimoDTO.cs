using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTOs;

public class EmprestimoDTO
{
    public int Id { get; set; }
    public int LivroId { get; set; }
    public int UsuarioId { get; set; }
    public StatusEmprestimo Status { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataPrevistaDevolucao { get; set; }
    public DateTime? DataDevolucao { get; set; }
}
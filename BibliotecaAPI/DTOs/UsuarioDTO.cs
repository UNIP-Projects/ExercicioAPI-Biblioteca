using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTOs;

public class UsuarioDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public TipoUsuario Tipo { get; set; } = TipoUsuario.Aluno;
    public bool Ativo { get; set; }
}
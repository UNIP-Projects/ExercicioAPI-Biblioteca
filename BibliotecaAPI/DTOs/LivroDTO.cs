namespace BibliotecaAPI.DTOs;

public class LivroDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public bool Disponivel { get; set; }
}
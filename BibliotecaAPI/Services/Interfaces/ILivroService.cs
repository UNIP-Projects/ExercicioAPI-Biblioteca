using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Services.Interfaces;

public interface ILivroService
{
    Task<List<LivroDTO>> GetAllAsync();
    Task<LivroDTO?> GetByIdAsync(int id);
    Task<LivroDTO> CreateAsync(LivroDTO dto);
    Task<LivroDTO?> UpdateAsync(int id, LivroDTO dto);
    Task<bool> DeleteAsync(int id);
}
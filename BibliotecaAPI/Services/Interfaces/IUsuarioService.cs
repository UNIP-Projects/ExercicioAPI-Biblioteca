using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Services.Interfaces;

public interface IUsuarioService
{
    Task<List<UsuarioDTO>> GetAllAsync();
    Task<UsuarioDTO?> GetByIdAsync(int id);
    Task<UsuarioDTO> CreateAsync(UsuarioDTO dto);
    Task<UsuarioDTO?> UpdateAsync(int id, UsuarioDTO dto);
    Task<bool> DeleteAsync(int id);
}
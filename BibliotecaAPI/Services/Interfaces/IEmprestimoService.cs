using BibliotecaAPI.DTOs;

namespace BibliotecaAPI.Services.Interfaces;

public interface IEmprestimoService
{
    Task<EmprestimoDTO?> GetByIdAsync(int id);
    Task<List<EmprestimoDTO>> GetAllAsync();
    Task<EmprestimoDTO> CriarAsync(EmprestimoCreateDTO dto);
    Task<EmprestimoDTO?> DevolverAsync(int id);
}
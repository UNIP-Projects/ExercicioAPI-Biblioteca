using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces;

public interface IEmprestimoRepository
{
    Task<Emprestimo?> GetByIdAsync(int id);
    Task<List<Emprestimo>> GetAllAsync();
    Task<List<Emprestimo>> GetByUsuarioAsync(int usuarioId);
    Task<List<Emprestimo>> GetAtivosByUsuarioAsync(int usuarioId);
    Task AddAsync(Emprestimo emprestimo);
    Task UpdateAsync(Emprestimo emprestimo);
}
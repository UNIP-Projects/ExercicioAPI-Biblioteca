using BibliotecaAPI.Models;

namespace BibliotecaAPI.Repositories.Interfaces;

public interface ILivroRepository
{
    Task<Livro?> GetByIdAsync(int id);
    Task<List<Livro>> GetAllAsync();
    Task AddAsync(Livro livro);
    Task UpdateAsync(Livro livro);
    Task DeleteAsync(int id);
}
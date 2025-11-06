using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly BibliotecaContext _context;
    public LivroRepository(BibliotecaContext context) => _context = context;

    public async Task AddAsync(Livro livro)
    {
        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Livros.FindAsync(id);
        if (entity != null)
        {
            _context.Livros.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Livro>> GetAllAsync() => _context.Livros.AsNoTracking().ToListAsync();

    public Task<Livro?> GetByIdAsync(int id) => _context.Livros.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);

    public async Task UpdateAsync(Livro livro)
    {
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
    }
}
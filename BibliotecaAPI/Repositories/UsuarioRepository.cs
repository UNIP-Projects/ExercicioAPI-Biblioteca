using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BibliotecaContext _context;
    public UsuarioRepository(BibliotecaContext context) => _context = context;

    public async Task AddAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Usuarios.FindAsync(id);
        if (entity != null)
        {
            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<List<Usuario>> GetAllAsync() => _context.Usuarios.AsNoTracking().ToListAsync();

    public Task<Usuario?> GetByIdAsync(int id) => _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }
}
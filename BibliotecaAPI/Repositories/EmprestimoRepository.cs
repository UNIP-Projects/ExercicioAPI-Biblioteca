using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaAPI.Repositories;

public class EmprestimoRepository : IEmprestimoRepository
{
    private readonly BibliotecaContext _context;
    public EmprestimoRepository(BibliotecaContext context) => _context = context;

    public async Task AddAsync(Emprestimo emprestimo)
    {
        _context.Emprestimos.Add(emprestimo);
        await _context.SaveChangesAsync();
    }

    public Task<List<Emprestimo>> GetAllAsync() =>
        _context.Emprestimos.AsNoTracking().ToListAsync();

    public Task<Emprestimo?> GetByIdAsync(int id) =>
        _context.Emprestimos.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

    public Task<List<Emprestimo>> GetByUsuarioAsync(int usuarioId) =>
        _context.Emprestimos.AsNoTracking().Where(e => e.UsuarioId == usuarioId).ToListAsync();

    public Task<List<Emprestimo>> GetAtivosByUsuarioAsync(int usuarioId) =>
        _context.Emprestimos.AsNoTracking().Where(e => e.UsuarioId == usuarioId && e.Status == StatusEmprestimo.Ativo).ToListAsync();

    public async Task UpdateAsync(Emprestimo emprestimo)
    {
        _context.Emprestimos.Update(emprestimo);
        await _context.SaveChangesAsync();
    }
}
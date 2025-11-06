using BibliotecaAPI.DTOs;
using BibliotecaAPI.Exceptions;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;

namespace BibliotecaAPI.Services;

public class LivroService : Interfaces.ILivroService
{
    private readonly ILivroRepository _repo;
    public LivroService(ILivroRepository repo) => _repo = repo;

    public async Task<LivroDTO> CreateAsync(LivroDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Titulo) || string.IsNullOrWhiteSpace(dto.Autor))
            throw new ValidationException("Título e Autor são obrigatórios.");

        var entity = new Livro
        {
            Titulo = dto.Titulo,
            Autor = dto.Autor,
            Isbn = dto.Isbn,
            Disponivel = dto.Disponivel
        };
        await _repo.AddAsync(entity);
        dto.Id = entity.Id;
        dto.Disponivel = entity.Disponivel;
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<List<LivroDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(l => new LivroDTO
        {
            Id = l.Id,
            Titulo = l.Titulo,
            Autor = l.Autor,
            Isbn = l.Isbn,
            Disponivel = l.Disponivel
        }).ToList();
    }

    public async Task<LivroDTO?> GetByIdAsync(int id)
    {
        var l = await _repo.GetByIdAsync(id);
        if (l == null) return null;
        return new LivroDTO
        {
            Id = l.Id,
            Titulo = l.Titulo,
            Autor = l.Autor,
            Isbn = l.Isbn,
            Disponivel = l.Disponivel
        };
    }

    public async Task<LivroDTO?> UpdateAsync(int id, LivroDTO dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Titulo = dto.Titulo;
        existing.Autor = dto.Autor;
        existing.Isbn = dto.Isbn;
        existing.Disponivel = dto.Disponivel;
        await _repo.UpdateAsync(existing);

        return new LivroDTO
        {
            Id = existing.Id,
            Titulo = existing.Titulo,
            Autor = existing.Autor,
            Isbn = existing.Isbn,
            Disponivel = existing.Disponivel
        };
    }
}
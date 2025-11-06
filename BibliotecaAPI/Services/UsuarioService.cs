using BibliotecaAPI.DTOs;
using BibliotecaAPI.Exceptions;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;

namespace BibliotecaAPI.Services;

public class UsuarioService : Interfaces.IUsuarioService
{
    private readonly IUsuarioRepository _repo;
    public UsuarioService(IUsuarioRepository repo) => _repo = repo;

    public async Task<UsuarioDTO> CreateAsync(UsuarioDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nome))
            throw new ValidationException("Nome é obrigatório.");

        var entity = new Usuario
        {
            Nome = dto.Nome,
            Tipo = dto.Tipo,
            Ativo = dto.Ativo
        };
        await _repo.AddAsync(entity);
        dto.Id = entity.Id;
        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return false;
        await _repo.DeleteAsync(id);
        return true;
    }

    public async Task<List<UsuarioDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();
        return list.Select(u => new UsuarioDTO
        {
            Id = u.Id,
            Nome = u.Nome,
            Tipo = u.Tipo,
            Ativo = u.Ativo
        }).ToList();
    }

    public async Task<UsuarioDTO?> GetByIdAsync(int id)
    {
        var u = await _repo.GetByIdAsync(id);
        if (u == null) return null;
        return new UsuarioDTO
        {
            Id = u.Id,
            Nome = u.Nome,
            Tipo = u.Tipo,
            Ativo = u.Ativo
        };
    }

    public async Task<UsuarioDTO?> UpdateAsync(int id, UsuarioDTO dto)
    {
        var existing = await _repo.GetByIdAsync(id);
        if (existing == null) return null;

        existing.Nome = dto.Nome;
        existing.Tipo = dto.Tipo;
        existing.Ativo = dto.Ativo;
        await _repo.UpdateAsync(existing);

        return new UsuarioDTO
        {
            Id = existing.Id,
            Nome = existing.Nome,
            Tipo = existing.Tipo,
            Ativo = existing.Ativo
        };
    }
}
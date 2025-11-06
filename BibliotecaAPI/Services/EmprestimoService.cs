using BibliotecaAPI.DTOs;
using BibliotecaAPI.Exceptions;
using BibliotecaAPI.Models;
using BibliotecaAPI.Repositories.Interfaces;

namespace BibliotecaAPI.Services;

public class EmprestimoService : Interfaces.IEmprestimoService
{
    private readonly IEmprestimoRepository _emprestimoRepo;
    private readonly ILivroRepository _livroRepo;
    private readonly IUsuarioRepository _usuarioRepo;

    public EmprestimoService(IEmprestimoRepository emprestimoRepo, ILivroRepository livroRepo, IUsuarioRepository usuarioRepo)
    {
        _emprestimoRepo = emprestimoRepo;
        _livroRepo = livroRepo;
        _usuarioRepo = usuarioRepo;
    }

    public async Task<EmprestimoDTO> CriarAsync(EmprestimoCreateDTO dto)
    {
        var livro = await _livroRepo.GetByIdAsync(dto.LivroId) ?? throw new NotFoundException("Livro não encontrado.");
        var usuario = await _usuarioRepo.GetByIdAsync(dto.UsuarioId) ?? throw new NotFoundException("Usuário não encontrado.");

        if (!usuario.Ativo) throw new BusinessException("Usuário inativo.");
        if (!livro.Disponivel) throw new BusinessException("Livro indisponível.");

        var ativosUsuario = await _emprestimoRepo.GetAtivosByUsuarioAsync(usuario.Id);
        var limite = usuario.Tipo switch
        {
            TipoUsuario.Aluno => 3,
            TipoUsuario.Professor => 5,
            TipoUsuario.Funcionario => 2,
            _ => 3
        };
        if (ativosUsuario.Count >= limite)
            throw new BusinessException($"Limite de empréstimos atingido para {usuario.Tipo}.");

        var diasPrazo = usuario.Tipo switch
        {
            TipoUsuario.Aluno => 7,
            TipoUsuario.Professor => 15,
            TipoUsuario.Funcionario => 7,
            _ => 7
        };

        var emprestimo = new Emprestimo
        {
            LivroId = livro.Id,
            UsuarioId = usuario.Id,
            DataEmprestimo = DateTime.UtcNow,
            DataPrevistaDevolucao = DateTime.UtcNow.Date.AddDays(diasPrazo),
            Status = StatusEmprestimo.Ativo
        };

        // Atualiza disponibilidade do livro
        livro.Disponivel = false;
        await _livroRepo.UpdateAsync(livro);
        await _emprestimoRepo.AddAsync(emprestimo);

        return new EmprestimoDTO
        {
            Id = emprestimo.Id,
            LivroId = emprestimo.LivroId,
            UsuarioId = emprestimo.UsuarioId,
            Status = emprestimo.Status,
            DataEmprestimo = emprestimo.DataEmprestimo,
            DataPrevistaDevolucao = emprestimo.DataPrevistaDevolucao,
            DataDevolucao = emprestimo.DataDevolucao
        };
    }

    public async Task<EmprestimoDTO?> DevolverAsync(int id)
    {
        var emprestimo = await _emprestimoRepo.GetByIdAsync(id);
        if (emprestimo == null) return null;
        if (emprestimo.Status == StatusEmprestimo.Devolvido) return new EmprestimoDTO
        {
            Id = emprestimo.Id,
            LivroId = emprestimo.LivroId,
            UsuarioId = emprestimo.UsuarioId,
            Status = emprestimo.Status,
            DataEmprestimo = emprestimo.DataEmprestimo,
            DataPrevistaDevolucao = emprestimo.DataPrevistaDevolucao,
            DataDevolucao = emprestimo.DataDevolucao
        };

        emprestimo.Status = StatusEmprestimo.Devolvido;
        emprestimo.DataDevolucao = DateTime.UtcNow;
        await _emprestimoRepo.UpdateAsync(emprestimo);

        // Libera o livro
        var livro = await _livroRepo.GetByIdAsync(emprestimo.LivroId);
        if (livro != null)
        {
            livro.Disponivel = true;
            await _livroRepo.UpdateAsync(livro);
        }

        return new EmprestimoDTO
        {
            Id = emprestimo.Id,
            LivroId = emprestimo.LivroId,
            UsuarioId = emprestimo.UsuarioId,
            Status = emprestimo.Status,
            DataEmprestimo = emprestimo.DataEmprestimo,
            DataPrevistaDevolucao = emprestimo.DataPrevistaDevolucao,
            DataDevolucao = emprestimo.DataDevolucao
        };
    }

    public async Task<List<EmprestimoDTO>> GetAllAsync()
    {
        var list = await _emprestimoRepo.GetAllAsync();
        return list.Select(e => new EmprestimoDTO
        {
            Id = e.Id,
            LivroId = e.LivroId,
            UsuarioId = e.UsuarioId,
            Status = e.Status,
            DataEmprestimo = e.DataEmprestimo,
            DataPrevistaDevolucao = e.DataPrevistaDevolucao,
            DataDevolucao = e.DataDevolucao
        }).ToList();
    }

    public async Task<EmprestimoDTO?> GetByIdAsync(int id)
    {
        var e = await _emprestimoRepo.GetByIdAsync(id);
        if (e == null) return null;
        return new EmprestimoDTO
        {
            Id = e.Id,
            LivroId = e.LivroId,
            UsuarioId = e.UsuarioId,
            Status = e.Status,
            DataEmprestimo = e.DataEmprestimo,
            DataPrevistaDevolucao = e.DataPrevistaDevolucao,
            DataDevolucao = e.DataDevolucao
        };
    }
}
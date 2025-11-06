using BibliotecaAPI.DTOs;
using BibliotecaAPI.Exceptions;
using BibliotecaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmprestimosController : ControllerBase
{
    private readonly IEmprestimoService _service;
    public EmprestimosController(IEmprestimoService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<EmprestimoDTO>>> Get() => await _service.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmprestimoDTO>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<EmprestimoDTO>> Post([FromBody] EmprestimoCreateDTO dto)
    {
        try
        {
            var created = await _service.CriarAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (BusinessException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{id:int}/devolver")]
    public async Task<ActionResult<EmprestimoDTO>> Devolver(int id)
    {
        var updated = await _service.DevolverAsync(id);
        return updated is null ? NotFound() : Ok(updated);
    }
}
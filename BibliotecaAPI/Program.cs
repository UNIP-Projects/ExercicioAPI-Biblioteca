using BibliotecaAPI.Data;
using BibliotecaAPI.Repositories;
using BibliotecaAPI.Repositories.Interfaces;
using BibliotecaAPI.Services;
using BibliotecaAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<BibliotecaContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Default")));

// Repositories
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

// Services
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEmprestimoService, EmprestimoService>();

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migrate & Seed
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<BibliotecaContext>();
    // Criar banco e tabelas sem migrations para simplificar a estrutura
    ctx.Database.EnsureCreated();

    if (!ctx.Livros.Any())
    {
        ctx.Livros.AddRange(
            new BibliotecaAPI.Models.Livro { Titulo = "Clean Code", Autor = "Robert C. Martin", Isbn = "9780132350884", Disponivel = true },
            new BibliotecaAPI.Models.Livro { Titulo = "Domain-Driven Design", Autor = "Eric Evans", Isbn = "9780321125217", Disponivel = true }
        );
    }
    if (!ctx.Usuarios.Any())
    {
        ctx.Usuarios.AddRange(
            new BibliotecaAPI.Models.Usuario { Nome = "Ana Silva", Tipo = BibliotecaAPI.Models.TipoUsuario.Aluno, Ativo = true },
            new BibliotecaAPI.Models.Usuario { Nome = "Carlos Souza", Tipo = BibliotecaAPI.Models.TipoUsuario.Professor, Ativo = true },
            new BibliotecaAPI.Models.Usuario { Nome = "João Santos", Tipo = BibliotecaAPI.Models.TipoUsuario.Funcionario, Ativo = true }
        );
    }
    ctx.SaveChanges();
}

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

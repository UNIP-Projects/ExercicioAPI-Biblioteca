# BibliotecaAPI

API de Biblioteca construída em .NET (ASP.NET Core) com Entity Framework Core e SQLite.

## Estrutura

- `BibliotecaAPI/`
  - `Program.cs`, `appsettings.json`, `BibliotecaAPI.csproj`
  - `Controllers/`: Livros, Usuários, Empréstimos
  - `Services/` e `Services/Interfaces/`
  - `Repositories/` e `Repositories/Interfaces/`
  - `Models/`, `DTOs/`
  - `Data/` (Contexto e Configurações)
  - `Exceptions/`

## Execução

1. Restaurar e compilar:
   ```bash
   dotnet build BibliotecaAPI/BibliotecaAPI.csproj
   ```
2. Executar API:
   ```bash
   dotnet run --project BibliotecaAPI/BibliotecaAPI.csproj
   ```
3. Swagger:
   - `http://localhost:5000/swagger`

## Banco de Dados

- Banco SQLite criado automaticamente via `EnsureCreated()` baseado nos modelos.
- Arquivos do banco (`biblioteca.db*`) são ignorados pelo Git.

## Publicação no GitHub

1. Inicializar Git e commit inicial:
   ```bash
   git init
   git add .
   git commit -m "Inicializa projeto BibliotecaAPI com estrutura limpa"
   git branch -M main
   ```
2. Adicionar remoto e enviar:
   ```bash
   git remote add origin <URL_DO_SEU_REPOSITORIO>
   git push -u origin main
   ```

## Observações

- Caso deseje versionar o esquema do banco, reintroduza migrations e troque `EnsureCreated()` por `Database.Migrate()` em `Program.cs`.
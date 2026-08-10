<div align="center">

# BibliotecaAPI

![Status](https://img.shields.io/badge/Status-Concluído-success)
![Curso](https://img.shields.io/badge/Curso-ADS_UNIP-blue)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?logo=dotnet&logoColor=white)
![SQLite](https://img.shields.io/badge/SQLite-003B57?logo=sqlite&logoColor=white)

</div>

---

API REST de gerenciamento de biblioteca desenvolvida em ASP.NET Core, criada como exercício acadêmico durante a graduação em Análise e Desenvolvimento de Sistemas (ADS) na UNIP.

> A aplicação gerencia livros, usuários e empréstimos, aplicando arquitetura em camadas (Controllers, Services, Repositories), persistência com Entity Framework Core e SQLite, e documentação interativa via Swagger.

## Sumário

- [Sobre](#sobre)
- [Arquitetura](#arquitetura)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Como Executar](#como-executar)
- [Banco de Dados](#banco-de-dados)
- [Conceitos Aplicados](#conceitos-aplicados)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Autor](#autor)

## Sobre

API que expõe endpoints REST para o gerenciamento de uma biblioteca, cobrindo três domínios principais: livros, usuários e empréstimos. O projeto foi organizado seguindo boas práticas de separação de responsabilidades, com camadas independentes e uso de DTOs para transferência de dados.

## Arquitetura

O projeto segue uma arquitetura em camadas:

- **Controllers** — recebem as requisições HTTP e expõem os endpoints REST.
- **Services** — concentram a lógica de negócio (com interfaces para desacoplamento).
- **Repositories** — abstraem o acesso a dados (com interfaces).
- **DTOs** — objetos de transferência de dados entre camadas.
- **Models** — entidades de domínio mapeadas pelo EF Core.
- **Data** — contexto do EF Core e configurações.
- **Exceptions** — tratamento centralizado de erros.

## Estrutura do Projeto

BibliotecaAPI/
├── Controllers/ # Livros, Usuários, Empréstimos
├── Services/
│ └── Interfaces/
├── Repositories/
│ └── Interfaces/
├── Models/
├── DTOs/
├── Data/ # Contexto e configurações do EF Core
├── Exceptions/
├── Program.cs
├── appsettings.json
└── BibliotecaAPI.csproj


## Como Executar

**Pré-requisitos:** .NET SDK instalado.

1. Restaurar e compilar:

dotnet build BibliotecaAPI/BibliotecaAPI.csproj


2. Executar a API:

dotnet run --project BibliotecaAPI/BibliotecaAPI.csproj


3. Acessar a documentação Swagger:

http://localhost:5000/swagger


## Banco de Dados

- Banco **SQLite** criado automaticamente via `EnsureCreated()` a partir dos modelos.
- Os arquivos do banco (`biblioteca.db*`) são ignorados pelo Git.
- Para versionar o esquema, é possível reintroduzir migrations e trocar `EnsureCreated()` por `Database.Migrate()` no `Program.cs`.

## Conceitos Aplicados

- **API REST**: endpoints HTTP para operações CRUD sobre os recursos.
- **Arquitetura em camadas**: separação entre Controllers, Services e Repositories.
- **Injeção de dependência**: uso de interfaces para desacoplar as camadas.
- **ORM com Entity Framework Core**: mapeamento objeto-relacional e acesso a dados.
- **DTOs**: transferência de dados desacoplada das entidades de domínio.
- **Tratamento de exceções**: camada dedicada ao tratamento de erros.
- **Documentação de API**: geração automática via Swagger.

## Tecnologias Utilizadas

- **C#** — linguagem principal
- **ASP.NET Core** — framework para APIs REST
- **Entity Framework Core** — ORM para acesso a dados
- **SQLite** — banco de dados
- **Swagger** — documentação interativa da API

## Autor

<table>
  <tr>
    <td align="center">
      <a href="https://github.com/TeuzLins">
        <img style="border-radius: 50%;" src="https://github.com/TeuzLins.png" width="100px;" alt="Teuz Lins"/><br />
        <sub><b>Teuz Lins</b></sub>
      </a><br />
      <sub>Back-end / Full Stack Developer</sub>
    </td>
  </tr>
</table>

**Mateus de Lima Lins Prestes**

- GitHub: [@TeuzLins](https://github.com/TeuzLins)
- LinkedIn: [Mateus de Lima Lins Prestes](https://www.linkedin.com/in/mateus-de-lima-lins-prestes-304a812b7/)

Exercício acadêmico do curso de Análise e Desenvolvimento de Sistemas (ADS) — UNIP.



using CadastroFilmes.Domain.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CadastroFilmes.Web.Context
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
        {
        }

        public DbSet<FilmeDto> Filmes { get; set; }
    }
}

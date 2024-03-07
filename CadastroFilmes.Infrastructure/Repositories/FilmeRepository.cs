using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Infrastructure.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private List<Filme> _filmes = null;

        public FilmeRepository() 
        {
            CarregarFilmes();
        }

        private void CarregarFilmes()
        {
            _filmes = new List<Filme>()
            {
                new Filme(1, "Titanic", "Drama", 120),
                new Filme(2, "Shrek", "Animação", 90) ,
                new Filme(3, "Matrix", "Ação", 90) ,
                new Filme(4, "Gente Grande", "Comédia", 90),        
                new Filme(5, "Click", "Comédia", 75),
            };
        }

        public void Cadastrar(Filme filme)
        {
            _filmes.Add(filme);
        }
        public void Atualizar(Filme filme)
        {
            Filme filmePesquisado = PesquisarPorId(filme.FilmeId);
            if(filmePesquisado != null)
            {
                _filmes.Remove(filmePesquisado);
                _filmes.Add(filme);
            }
        }

        public void Excluir(int id) 
        {
            Filme filmePesquisado = PesquisarPorId(id);
            if (filmePesquisado != null)
            {
                _filmes.Remove(filmePesquisado);
            }
        }

        public Filme PesquisarPorId(int id)
        {
            Filme result = _filmes.FirstOrDefault(p => p.FilmeId == id);
            return result;
        }

        public List<Filme> Listar()
        {
            return _filmes;
        }
    }
}

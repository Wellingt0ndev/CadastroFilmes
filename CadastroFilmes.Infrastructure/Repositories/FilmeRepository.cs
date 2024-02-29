using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;


namespace CadastroFilmes.Infrastructure.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private List<Filme> _filmes = new List<Filme>();

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

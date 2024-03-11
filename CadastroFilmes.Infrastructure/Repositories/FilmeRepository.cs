using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.Exceptions;

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
            try
            {
            _filmes.Add(filme);
            }
            catch(Exception ex)
            {
                var message = "[RepositoryException] - Falha ao cadastrar filme";
                throw new RepositoryException(message, ex);
            }             
        }
        public void Atualizar(Filme filme)
        {
            try
            {
            Filme filmePesquisado = PesquisarPorId(filme.FilmeId);
            if(filmePesquisado != null)
            {
                _filmes.Remove(filmePesquisado);
                _filmes.Add(filme);
            }
            }
            catch(Exception ex)
            {
                var message = "[RepositoryException] - Falha ao atualizar filme";
                throw new RepositoryException(message, ex);
            }
        }

        public void Excluir(int id) 
        {            
            try
            {
                Filme filmePesquisado = PesquisarPorId(id);
                if (filmePesquisado != null)
                {
                    _filmes.Remove(filmePesquisado);
                }
            }
            catch (Exception ex)
            {
                var message = "[RepositoryException] - Falha ao excluir filme";
                throw new RepositoryException(message, ex);
            }
        }


        public Filme PesquisarPorId(int id)
        {            
            try
            {
                Filme result = _filmes.FirstOrDefault(p => p.FilmeId == id);
                return result;
            }
            catch (Exception ex)
            {
                var message = "[RepositoryException] - Falha ao pesquisar filme";
                throw new RepositoryException(message, ex);
            }

        }


        public List<Filme> Listar()
        {            
            try
            {
                return _filmes;
            }
            catch (Exception ex)
            {
                var message = "[RepositoryException] - Falha ao listar filme";
                throw new RepositoryException(message, ex);
            }
        }
    }
}

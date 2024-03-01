using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Infrastructure.Repositories;
using CadastroFilmes.Services;

namespace CadastroFilmes.SimpleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            int op = 3;

            switch(op)
            {
                case 1:
                    ValidaObjetoFilme();
                    break;
                case 2:
                    ValidaCamadaRepositorio();
                    break;
                case 3:
                    ValidaCamadaService();
                    break;
            }

        }

        static void ValidaObjetoFilme()
        {
            Filme filme = new Filme(1, "Titanic", "Drama", 135);
            filme.ValidarPropriedade();
            Console.WriteLine($"Filme: {filme.Nome}, Genero: {filme.Genero}");

            Filme filme2 = new Filme(2, "Shrek", "Animação", 105);            
            filme2.ValidarPropriedade();
            Console.WriteLine($"Filme: {filme2.Nome}, Genero: {filme2.Genero}");
        }

        static void ValidaCamadaRepositorio()
        {
            FilmeRepository repository = new FilmeRepository();
            Filme filme = new Filme(1, "Titanic", "Drama", 135);
            Filme filme2 = new Filme(2, "Shrek", "Animação", 105);

            repository.Cadastrar(filme);
            repository.Cadastrar(filme2);

            List<Filme> filmes = repository.Listar();

            Filme filmePesquisado = repository.PesquisarPorId(filme.FilmeId);
        }

        static void ValidaCamadaService()
        {
            IFilmeRepository filmeRepository = new FilmeRepository();
            IFilmeService filmeService = new FilmeService(filmeRepository);

            Filme filme = new Filme(1, "Titanic", "Drama", 135);
            Filme filme2 = new Filme(2, "Shrek", "Animação", 105);
            Filme filme3 = new Filme(3, "Matrix", "Ação", 85);

            List<Filme> filmes = new List<Filme>() { filme, filme2, filme3 };

            foreach(var item in filmes)
            {
                filmeService.Cadastrar(item);
            }

            var listaDeFilmes = filmeService.Listar();
        }
    }
}

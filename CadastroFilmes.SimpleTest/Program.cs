using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Infrastructure.Repositories;

namespace CadastroFilmes.SimpleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ValidaObjetoFilme();
            ValidaCamadaRepositorio();
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
    }
}

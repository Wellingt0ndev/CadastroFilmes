using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.SimpleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            ValidaObjetoFilme();
        }

        static void ValidaObjetoFilme()
        {
            Filme filme = new Filme(1, "Titanic", "Drama", 135);
            filme.ValidarPropriedade();
            Console.WriteLine($"Filme: {filme.Nome}, Genero: {filme.Genero}");

            Filme filme2 = new Filme();
            filme2.Nome = "Sherek";
            filme2.ValidarPropriedade();
            Console.WriteLine($"Filme: {filme2.Nome}, Genero: {filme2.Genero}");
        }
    }
}

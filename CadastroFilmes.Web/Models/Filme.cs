namespace CadastroFilmes.Web.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }

        public Filme()
        {
        }

        public Filme(string nome)
        {
            Nome = nome;
        }

        public Filme(string nome, string genero) : this(nome)
        {
            Genero = genero;            
        }

        public Filme(int id, string nome, string genero):this(nome,genero)
        {
            Id = id;            
        }
    }
}

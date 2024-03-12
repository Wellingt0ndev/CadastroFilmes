namespace CadastroFilmes.Domain.Entities;
/// <summary>
/// Classe para registro de filmes
/// </summary>

public class Filme
{
    #region Propriedades
    public int FilmeId { get;}
    public string Nome { get;}
    public string Genero { get;}
    public int Duracao { get;}
    #endregion

    #region Construtores
    /// <summary>
    /// Construtor de Filmes
    /// </summary>
    /// <param name="id">Recebe um campo númerico do tipo int ex: 2</param>
    /// <param name="nome">Recebe um campo texto para nome do filme ex: Rambo</param>
    /// <param name="genero">Recebe um campo texto com o genero do filme ex: ação</param>
    /// <param name="duracao">Recebe a duração do filme ex: 121 </param>
    public Filme(int id, string nome, string genero, int duracao) : this(nome, genero, duracao)
    {
        FilmeId = id;
    }
    public Filme(string nome, string genero, int duracao)
    {
        Nome = nome;
        Genero = genero;
        Duracao = duracao;
    }

    public Filme()
    {
    }  
    
    #endregion

    #region Métodos
    public void ValidarPropriedade()
    {
        if (string.IsNullOrEmpty(this.Nome))
        {
            throw new Exception("Campo nome é obrigatório");
        }
        if (string.IsNullOrEmpty(this.Genero))
        {
            throw new Exception("Campo genero é obrigatório");
        }
        if (this.Duracao <= 0)
        {
            throw new Exception("Campo Duração é obrigatório");
        }
    }
    #endregion

}

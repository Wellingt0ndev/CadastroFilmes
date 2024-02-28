using CadastroFilmes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private List<Filme> filmes = new List<Filme>();

        public FilmeController() 
        {
            CarregarFilmes();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var filmesOrdenados = filmes.OrderBy(x => x.Nome).ToList();
            return Ok(filmesOrdenados);
        }

        [HttpGet("{id}")]
        public ActionResult Pesquisar(int id)
        {
            var filmePesquisado = filmes.FirstOrDefault(x => x.Id.Equals(id));
            if (filmePesquisado == null)
                return BadRequest($"O filme com o id {id} não foi localizado");
            return Ok(filmePesquisado);
        }

        [HttpPost]
        public ActionResult Cadastrar([FromBody] Filme filme)
        {
            int proximoId = filmes.Count;
            proximoId++;

            Filme objFilme = new Filme(proximoId, filme.Nome, filme.Genero);
            filmes.Add(filme);
            return Ok($"Cadastro de filme {filme.Nome} realizado com sucesso");
        }

        private void CarregarFilmes()
        {
            Filme filme1 = new Filme(1, "Titanic", "Drama");
            Filme filme2 = new Filme(2, "Top Gun", "Ação");
            Filme filme3 = new Filme(3, "Avatar", "Fantasia");
            Filme filme4 = new Filme(4, "Shrek 2", "Animação");
            filmes.Add(filme1);
            filmes.Add(filme2);
            filmes.Add(filme3);
            filmes.Add(filme4);
        }

    }
}

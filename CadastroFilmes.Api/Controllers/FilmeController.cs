using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Dtos;
using CadastroFilmes.Domain.Entities;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase, IGenericController<FilmeDto, int>
    {
        private readonly IFilmeService _filmeService;

        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [HttpPatch]
        public ActionResult Atualizar(FilmeDto dto)
        {
            Filme entidade = new Filme(dto.Id, dto.Nome, dto.Genero, dto.Duracao);
            _filmeService.Atualizar(entidade);
            var message = "Atualizado com sucesso";
            return Ok(message);
        }

        [HttpPost]
        public ActionResult Cadastrar(FilmeDto dto)
        {
            Filme entidade = new Filme(dto.Id, dto.Nome, dto.Genero, dto.Duracao);
            _filmeService.Cadastrar(entidade);
            var message = "Cadastro efetuado com sucesso";
            return Ok(message);
        }
        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        { 
            _filmeService.Excluir(id);
            var message = "Filme excluido";
            return Ok(message);
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var result = _filmeService.Listar(); ;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult PesquisarPorId(int id)
        {
            var result = _filmeService.PesquisarPorId(id);
            return Ok(result);
        }
    }
}

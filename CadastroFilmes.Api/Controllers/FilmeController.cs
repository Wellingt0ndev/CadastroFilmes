using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Dtos;
using CadastroFilmes.Domain.Entities;
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

        public ActionResult Atualizar(FilmeDto entidade)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Cadastrar(FilmeDto dto)
        {
            Filme entidade = new Filme(dto.FilmeId, dto.Nome, dto.Genero, dto.Duracao);
            _filmeService.Cadastrar(entidade);
            var message = "Cadastro efetuado com sucesso";
            return Ok(message);
        }

        public ActionResult Excluir(int id)
        {
            throw new NotImplementedException();
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

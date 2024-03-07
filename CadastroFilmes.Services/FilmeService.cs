using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService (IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public void Atualizar(Filme entidade)
        {
            _filmeRepository.Atualizar(entidade);
        }

        public void Cadastrar(Filme entidade)
        {
            _filmeRepository.Cadastrar(entidade);
        }

        public void Excluir(int id)
        {
            _filmeRepository.Excluir(id);
        }

        public List<Filme> Listar()
        {
            var result = _filmeRepository.Listar();
            return result;
        }

        public Filme PesquisarPorId(int id)
        {
            var filme = _filmeRepository.PesquisarPorId(id);
            return filme;
        }
    }
}

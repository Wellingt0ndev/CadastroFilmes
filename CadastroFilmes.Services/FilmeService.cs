using CadastroFilmes.Domain.Contracts;
using CadastroFilmes.Domain.Entities;
using CadastroFilmes.Domain.Exceptions;
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
            try
            {
                _filmeRepository.Atualizar(entidade);
            }
            catch(RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "[ServiceException] - Falha ao atualizar um filme";
                throw new ServiceException(message, ex);
            }

        }

        public void Cadastrar(Filme entidade)
        {
            try
            {
                _filmeRepository.Cadastrar(entidade);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "[ServiceException] - Falha ao cadastrar um filme";
                throw new ServiceException(message, ex);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                _filmeRepository.Excluir(id);
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "[ServiceException] - Falha ao excluir um filme";
                throw new ServiceException(message, ex);
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                var result = _filmeRepository.Listar();
                return result;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "[ServiceException] - Falha ao listar um filme";
                throw new ServiceException(message, ex);
            }
        }

        public Filme PesquisarPorId(int id)
        {
            try
            {
                var filme = _filmeRepository.PesquisarPorId(id);
                return filme;
            }
            catch (RepositoryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                var message = "[ServiceException] - Falha ao pesquisar um filme";
                throw new ServiceException(message, ex);
            }
        }
    }
}

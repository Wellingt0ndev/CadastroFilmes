using CadastroFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Contracts
{
    public interface IGenericRepoService<T, Y> where T : class
    {
        void Cadastrar(T entidade);

        void Atualizar(T entidade);

        void Excluir(Y id);
        List<Filme> Listar();

        Filme PesquisarPorId(Y id);
    }
}

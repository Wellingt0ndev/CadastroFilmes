using CadastroFilmes.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFilmes.Domain.Contracts
{
    public interface IGenericController<T, Y> where T : class
    {
        ActionResult Cadastrar(T entidade);

        ActionResult Atualizar(T entidade);

        ActionResult Excluir(Y id);
        ActionResult Listar();

        ActionResult PesquisarPorId(Y id);
    }
    
}

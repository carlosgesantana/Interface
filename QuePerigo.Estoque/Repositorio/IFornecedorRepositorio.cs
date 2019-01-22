using System.Collections.Generic;
using QuePerigo.Estoque.Models;

namespace QuePerigo.Repositorio
{
    public interface IFornecedorRepositorio
    {
        List<Fornecedor> GetFornecedores();
        Fornecedor GetFornecedorFromId(int idFornecedor);
    }
}
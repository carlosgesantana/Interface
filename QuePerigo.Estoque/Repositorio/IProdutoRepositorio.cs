using System.Collections.Generic;
using QuePerigo.Estoque.Models;

namespace QuePerigo.Repositorio
{
    public interface IProdutoRepositorio
    {
        List<Produto> GetProdutos(string descricaoCurta);
        void Salvar(Produto produto);
    }
}
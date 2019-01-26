using System.Collections.Generic;
using QuePerigo.Estoque.Models;

namespace QuePerigo.Repositorio
{
    public interface ILocalizacaoRepositorio
    {
        List<Localizacao> GetLocalizacoes(int idFornecedor);
    }
}
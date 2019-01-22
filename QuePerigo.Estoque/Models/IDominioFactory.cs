using System.Collections.Generic;

namespace QuePerigo.Estoque.Models
{
    public interface IDominioFactory
    {
        IDictionary<int, string> GetDominio(string dominioName);
    }
}
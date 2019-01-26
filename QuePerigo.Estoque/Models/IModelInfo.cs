using System.Collections.Generic;

namespace QuePerigo.Estoque.Models
{
    public interface IModelInfo
    {
        Dictionary<string, Info> GetInfo(string className);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Utilidades
{
    public static class Check<T>
    {
        public static bool IsNullOrEmpty(IList<T> list)
        {
            return (list == null || !list.Any());
        }
    }
}

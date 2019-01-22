using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class Especificacao
    {
        public decimal PesoLiquido { get; set; }
        public decimal PesoBruto { get; set; }
        public decimal Largura { get; set; }
        public decimal Altura { get; set; }
        public decimal Profundidade { get; set; }
        public DateTime DataValidade { get; set; }
        public int Garantia { get; set; }
    }
}

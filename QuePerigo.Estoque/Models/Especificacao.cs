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

        public Especificacao()
        {
            PesoLiquido = 1.00M;
            PesoBruto = 1.00M;
            Largura = 1.00M;
            Altura = 1.00M;
            Profundidade = 1.00M;
            DataValidade = DateTime.MaxValue;
            Garantia = 0; //Cálculo em aberto
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class Produto
    {
        public string IdBling { get; set; }
        public int Id { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public string DescricaoCurta { get; set; }
        public string DescricaoCompleta { get; set; }
        public int Quantidade { get; set; }
        //public int IdMarca { get; set; } --Decidir se existirá esse campo
        public string NCM { get; set; }
        public string Observacoes { get; set; }
        public bool IsNacional { get; set; }
        public decimal Preco { get; set; }
        public bool HasEstoque { get; set; }
        public decimal Custo { get; set; }
        public string CodigoBarraEmbalagem { get; set; }
        public string CodigoBarra { get; set; }
        public string CEST { get; set; }
        public List<Imagem> Imagens { get; set; }
    }
}

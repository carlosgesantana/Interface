using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Especificacao = new Especificacao();
        }

        public string Id { get; set; } //Tam: 25, Não Nulo
        public string Descricao { get; set; } //Tam: 100, Não Nulo
        public Fornecedor Fornecedor { get; set; } //Não Nulo
        public Marca Marca { get; set; } //Nulo
        public Localizacao Localizacao { get; set; } //Não Nulo
        public Especificacao Especificacao { get; set; } //Não Nulo, Padrão: 1
        public string IdBling { get; set; } //Tam: 10, Nulo
        public string Unidade { get; set; } //Tam: 2, Não Nulo, Padrão: 'UN'
        public string NCM { get; set; } //Tam: 50, Nulo
        public int Origem { get; set; } //Não Nulo, Padrão: 0
        public decimal Preco { get; set; } //Tam: 18;2, Não Nulo
        public decimal ValorIPIFixo { get; set; } //Tam: 18;2, Nulo
        public string Observacoes { get; set; } //Tam: 500, Nulo
        public char Situacao { get; set; } //Tam: 1, Não Nulo, Padrão: 'A'
        public int Quantidade { get; set; } //Não Nulo
        public decimal Custo { get; set; } //Tam: 18;2, Não Nulo
        public string IdFabricacao { get; set; } //Tam: 25, Não Nulo
        public int QuantidadeMinima { get; set; } //Nulo
        public int QuantidadeMaxima { get; set; } //Nulo
        public string CodigoBarra { get; set; } //Tam: 50, Nulo
        public string CodigoBarraEmbalagem { get; set; } //Tam: 50, Nulo
        public string DescricaoComplementar { get; set; } //Tam: 500, Não Nulo
        public string TipoProducao { get; set; } //Tam: 1, Não Nulo, Padrão: T
        public string TipoItem { get; set; } //Tam: 40, Não Nulo, Padrão: 'Mercadoria para revenda'
        public decimal Tributos { get; set; } //Tam: 18;2, Nulo
        public string CEST { get; set; } //Tam: 50, Nulo
        public string DescricaoCurta { get; set; } //Tam: 200, Não Nulo
        public int CrossDocking { get; set; } //Nulo
        public List<Imagem> Imagens { get; set; } //Nulo
        public string Condicao { get; set; } //Tam: 10, Não Nulo, Padrão: 'Novo'

    }
}

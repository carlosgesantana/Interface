using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class ModelInfo : IModelInfo
    {
        private Dictionary<string, Info> produtoInfo;

        public Dictionary<string, Info> GetInfo(string className)
        {
            Dictionary<string, Info> info = null;

            switch (className)
            {
                case "Produto":
                    {
                        if (produtoInfo == null)
                        {
                            produtoInfo = new Dictionary<string, Info>
                            {
                                {"Id", new Info(25, true) },
                                {"Descricao", new Info(100, true) },
                                {"Fornecedor", new Info(true) },
                                {"Marca", new Info(false) },
                                {"Localizacao", new Info(true) },
                                {"Especificacao", new Info(true) },
                                {"IdBling", new Info(10, false) },
                                {"Unidade", new Info(2, true) },
                                {"NCM", new Info(50, false) },
                                {"Origem", new Info(true) },
                                {"Preco", new Info(18, true) },
                                {"ValorIPIFixo", new Info(false) },
                                {"Observacoes", new Info(500, false) },
                                {"Situacao", new Info(1, true) },
                                {"Quantidade", new Info(true) },
                                {"Custo", new Info(18, true) },
                                {"IdFabricacao", new Info(25, true) },
                                {"QuantidadeMinima", new Info(false) },
                                {"QuantidadeMaxima", new Info(false) },
                                {"CodigoBarra", new Info(50, false) },
                                {"CodigoBarraEmbalagem", new Info(50, false) },
                                {"DescricaoComplementar", new Info(500, true) },
                                {"TipoProducao", new Info(1, true) },
                                {"TipoItem", new Info(40, true) },
                                {"Tributos", new Info(false) },
                                {"CEST", new Info(50, false) },
                                {"DescricaoCurta", new Info(200, true) },
                                {"CrossDocking", new Info(false) },
                                {"Imagens", new Info(false) },
                                {"Condicao", new Info(10, true) }
                            };
                        }

                        info = produtoInfo;

                        break;
                    }
                default:
                    break;
            }

            return info;
        }
    }
}

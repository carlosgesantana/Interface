using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Estoque.Models
{
    public class DominioFactory : IDominioFactory
    {
        private IDictionary<int, string> dominioCondicao;
        private IDictionary<int, string> dominioUnidade;
        private IDictionary<int, string> dominioSituacao;
        private IDictionary<int, string> dominioOrigem;
        private IDictionary<int, string> dominioTipoItem;

        public IDictionary<int, string> GetDominio(string dominioName)
        {
            IDictionary<int, string> dominio = null;

            switch (dominioName)
            {
                case "Unidade":
                    {
                        if (dominioUnidade == null)
                        {
                            dominioUnidade = new Dictionary<int, string>
                            {
                                { 1, "UN" },
                                { 2, "KG" },
                                { 3, "PÇ" }
                            };
                        }

                        dominio = dominioUnidade;

                        break;
                    }
                case "Situacao":
                    {
                        if (dominioSituacao == null)
                        {
                            dominioSituacao = new Dictionary<int, string>
                            {
                                { 1, "ATIVO" },
                                { 2, "INATIVO" }
                            };
                        }


                        dominio = dominioSituacao;

                        break;
                    }
                case "Origem":
                    {
                        if (dominioOrigem == null)
                        {
                            dominioOrigem = new Dictionary<int, string>
                            {
                                { 0, "NACIONAL" },
                                { 1, "IMPORTADO" }
                            };
                        }

                        dominio = dominioOrigem;

                        break;
                    }
                case "TipoItem":
                    {
                        if (dominioTipoItem == null)
                        {
                            dominioTipoItem = new Dictionary<int, string>
                            {
                                { 1, "Mercadoria para revenda" },
                                { 2, "Matéria-Prima" },
                                { 3, "Embalagem" },
                                { 4, "Produto em Processo" },
                                { 5, "Produto Acabado" },
                                { 6, "Subproduto" },
                                { 7, "Produto Intermediário" },
                                { 8, "Material de Uso e Consumo" },
                                { 9, "Ativo Imobilizado" },
                                { 10, "Serviços" },
                                { 11, "Outros insumos" },
                                { 12, "Outras" }
                            };
                        }

                        dominio = dominioTipoItem;

                        break;
                    }
                case "Condicao":
                    {
                        if (dominioCondicao == null)
                        {
                            dominioCondicao = new Dictionary<int, string>
                            {
                                { 1, "Novo" },
                                { 2, "Usado"}
                            };
                        }

                        dominio = dominioCondicao;

                        break;
                    }
                default:
                    throw new ArgumentException("Domínio inválido: " + dominioName, "dominioName");
            }

            return dominio;
        }
    }
}

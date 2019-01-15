using QuePerigo.Dados;
using QuePerigo.Estoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuePerigo.Repositorio
{
    public class ProdutoRepositorio : Repositorio, IProdutoRepositorio
    {
        public ProdutoRepositorio(IConexaoDados conexaoDados) : base(conexaoDados)
        {

        }

        public List<Produto> GetProdutos(string descricaoCurta)
        {
            List<Produto> produtos = new List<Produto>();

            if (!string.IsNullOrEmpty(descricaoCurta))
            {
                DataTable dataTable = conexaoDados.Consultar("SELECT ID_PROD, DESC_CURTA, ID_FORNECEDOR, CUSTO, PRECO FROM TBL_Produtos WHERE DESC_CURTA LIKE '%" + descricaoCurta + "%'");

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    Produto produto = new Produto()
                    {
                        Id = row["ID_PROD"] as string,
                        DescricaoCurta = row["DESC_CURTA"] as string,
                        Fornecedor = new Fornecedor() { Id = (int) row["ID_FORNECEDOR"], Nome = "Circuit" },
                        Custo = (decimal)row["CUSTO"],
                        Preco = (decimal)row["PRECO"]
                    };
                    produtos.Add(produto);
                }
            }

            return produtos;
        }
    }
}

using QuePerigo.Dados;
using QuePerigo.Estoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace QuePerigo.Repositorio
{
    public class ProdutoRepositorio : Repositorio, IProdutoRepositorio
    {
        public ProdutoRepositorio(IConexaoDados bdEstoque) : base(bdEstoque)
        {

        }

        public List<Produto> GetProdutos(string descricaoCurta)
        {
            List<Produto> produtos = new List<Produto>();

            if (!string.IsNullOrEmpty(descricaoCurta))
            {
                SqlCommand dbCommand = new SqlCommand("SELECT ID_PROD, DESC_CURTA, ID_FORNECEDOR, CUSTO, PRECO, ESTOQUE FROM TBL_Produtos WHERE DESC_CURTA LIKE @DESC_CURTA");

                dbCommand.Parameters.AddWithValue("@DESC_CURTA", "%" + descricaoCurta + "%");

                DataTable dataTable = bdEstoque.Consultar(dbCommand, null);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    Produto produto = new Produto()
                    {
                        Id = row["ID_PROD"] as string,
                        DescricaoCurta = row["DESC_CURTA"] as string,
                        Fornecedor = new Fornecedor() { Id = (int)row["ID_FORNECEDOR"] },
                        Custo = (decimal)row["CUSTO"],
                        Preco = (decimal)row["PRECO"],
                        Quantidade = (int)row["ESTOQUE"]
                    };
                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        public void Salvar(Produto produto)
        {
            DbCommand command = new SqlCommand(
                "INSERT INTO TBL_Produtos VALUES " +
                "(" +
                    "@ID_PROD, @ID_BLING, @ID_FORNECEDOR, @NCM, " +
                    "@OBS, @ORIGEM_NAC, @CUSTO, @PRECO, @STATUS_PROD, " +
                    "@ESTOQUE, @GTIN_EAN_EMB, @GTIN_EAN, @CEST, @DESC_CURTA, @DESC_COMPLETA" +
                ")");

            List<DbParameter> sqlParameters = new List<DbParameter>();

            sqlParameters.Add(new SqlParameter("@ID_PROD", produto.Id));
            sqlParameters.Add(new SqlParameter("@ID_BLING", produto.IdBling ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@ID_FORNECEDOR", produto.Fornecedor.Id));
            sqlParameters.Add(new SqlParameter("@NCM", produto.NCM ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@OBS", produto.Observacoes ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@ORIGEM_NAC", produto.Origem));
            sqlParameters.Add(new SqlParameter("@CUSTO", produto.Custo));
            sqlParameters.Add(new SqlParameter("@PRECO", produto.Preco));
            sqlParameters.Add(new SqlParameter("@STATUS_PROD", produto.Situacao));
            sqlParameters.Add(new SqlParameter("@ESTOQUE", produto.Quantidade));
            sqlParameters.Add(new SqlParameter("@GTIN_EAN_EMB", produto.CodigoBarraEmbalagem ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@GTIN_EAN", produto.CodigoBarra ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@CEST", produto.CEST ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@DESC_CURTA", produto.DescricaoCurta));
            sqlParameters.Add(new SqlParameter("@DESC_COMPLETA", produto.DescricaoComplementar));

            bdEstoque.Executar(command, sqlParameters);
        }
    }
}

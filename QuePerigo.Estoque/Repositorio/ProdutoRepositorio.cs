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
                SqlCommand dbCommand = new SqlCommand("SELECT id_produto, descricao_curta, id_fornecedor, custo, preco, quantidade FROM Produtos WHERE descricao_curta LIKE @descricao_curta");

                dbCommand.Parameters.AddWithValue("@descricao_curta", "%" + descricaoCurta + "%");

                DataTable dataTable = bdEstoque.Consultar(dbCommand, null);

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    Produto produto = new Produto()
                    {
                        Id = row["id_produto"] as string,
                        DescricaoCurta = row["descricao_curta"] as string,
                        Fornecedor = new Fornecedor() { Id = (int)row["id_fornecedor"] },
                        Custo = (decimal)row["custo"],
                        Preco = (decimal)row["preco"],
                        Quantidade = (int)row["quantidade"]
                    };
                    produtos.Add(produto);
                }
            }

            return produtos;
        }

        public void Salvar(Produto produto)
        {
            DbCommand command = new SqlCommand(
                "INSERT INTO Produtos VALUES " +
                "(" +
                    "@tipo_item, @condicao, @tipo_producao, @id_produto, " +
                    "@id_bling, @descricao, @descricao_curta, @descricao_complementar, " +
                    "@unidade, @id_fornecedor, @id_localizacao, @quantidade, " +
                    "@situacao, @custo, @preco, @codigo_barra, @codigo_barra_embalagem" +
                    "@ncm, @origem, @cest, @obs" +
                ")");

            List<DbParameter> sqlParameters = new List<DbParameter>();

            sqlParameters.Add(new SqlParameter("@tipo_item", produto.TipoItem));
            sqlParameters.Add(new SqlParameter("@condicao", produto.Condicao));
            sqlParameters.Add(new SqlParameter("@tipo_producao", produto.TipoProducao));
            sqlParameters.Add(new SqlParameter("@id_produto", produto.Id));
            sqlParameters.Add(new SqlParameter("@id_bling", produto.IdBling ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@descricao", produto.Descricao));
            sqlParameters.Add(new SqlParameter("@descricao_curta", produto.DescricaoCurta));
            sqlParameters.Add(new SqlParameter("@descricao_complementar", produto.DescricaoComplementar));
            sqlParameters.Add(new SqlParameter("@unidade", produto.Unidade));
            sqlParameters.Add(new SqlParameter("@id_fornecedor", produto.Fornecedor.Id));
            sqlParameters.Add(new SqlParameter("@id_localizacao", produto.Localizacao.Id));
            sqlParameters.Add(new SqlParameter("@quantidade", produto.Quantidade));
            sqlParameters.Add(new SqlParameter("@situacao", produto.Situacao));
            sqlParameters.Add(new SqlParameter("@custo", produto.Custo));
            sqlParameters.Add(new SqlParameter("@preco", produto.Preco));
            sqlParameters.Add(new SqlParameter("@codigo_barra", produto.CodigoBarra ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@codigo_barra_embalagem", produto.CodigoBarraEmbalagem ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@ncm", produto.NCM ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@origem", produto.Origem));
            sqlParameters.Add(new SqlParameter("@cest", produto.CEST ?? (object)DBNull.Value) { IsNullable = true });
            sqlParameters.Add(new SqlParameter("@obs", produto.Observacoes ?? (object)DBNull.Value) { IsNullable = true });
            
            bdEstoque.Executar(command, sqlParameters);
        }
    }
}

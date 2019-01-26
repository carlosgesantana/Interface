using QuePerigo.Dados;
using QuePerigo.Estoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuePerigo.Repositorio
{
    public class FornecedorRepositorio : Repositorio, IFornecedorRepositorio
    {
        public FornecedorRepositorio(IConexaoDados bdEstoque) : base(bdEstoque)
        {

        }

        public Fornecedor GetFornecedorFromId(int idFornecedor)
        {

            Fornecedor fornecedor = null;

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Fornecedores WHERE id_fornecedor = @id_fornecedor");
            List<DbParameter> dbParameterList = new List<DbParameter>();

            dbParameterList.Add(new SqlParameter("@id_fornecedor", idFornecedor));

            DataTable dataTable = bdEstoque.Consultar(sqlCommand, dbParameterList);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];


                fornecedor = new Fornecedor()
                {
                    Id = (int)row["id_fornecedor"],
                    Nome = row["nome"] as string
                };


            }

            return fornecedor;
        }

        public List<Fornecedor> GetFornecedores()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            DbCommand sqlCommand = new SqlCommand("SELECT * FROM Fornecedores");

            DataTable dataTable = bdEstoque.Consultar(sqlCommand, null);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];

                fornecedores.Add(
                    new Fornecedor()
                    {
                        Id = (int)row["id_fornecedor"],
                        Nome = row["nome"] as string
                    }
                );

            }

            return fornecedores;
        }
    }
}

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
    public class LocalizacaoRepositorio : Repositorio, ILocalizacaoRepositorio
    {
        public LocalizacaoRepositorio(IConexaoDados bdEstoque) : base(bdEstoque)
        {

        }

        public List<Localizacao> GetLocalizacoes(int idFornecedor)
        {
            List<Localizacao> localizacoes = new List<Localizacao>();

            SqlCommand sqlCommand = new SqlCommand("SELECT L.id_localizacao, L.cidade, L.estado FROM Localizacoes L JOIN LocalizacaoFornecedor LF ON L.id_localizacao = LF.id_localizacao WHERE LF.id_fornecedor = @id_fornecedor");

            List<DbParameter> dbParameterList = new List<DbParameter>();
            dbParameterList.Add(new SqlParameter("@id_fornecedor", idFornecedor));

            DataTable dataTable = bdEstoque.Consultar(sqlCommand, dbParameterList);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];


                localizacoes.Add
                (
                    new Localizacao()
                    {
                        Id = (int)row["id_localizacao"],
                        Cidade = row["cidade"] as string,
                        Estado = row["estado"] as string
                    }
                );


            }

            return localizacoes;
        }
    }
}

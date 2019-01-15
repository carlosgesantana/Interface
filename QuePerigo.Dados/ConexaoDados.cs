using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace QuePerigo.Dados
{
    public class ConexaoDados : IConexaoDados
    {
        private IDbConnection connection;

        public ConexaoDados(IDbConnection connection)
        {
            this.connection = connection;
        }

        public DataTable Consultar(string sqlCommandText)
        {
            this.connection.Open();

            IDbCommand command = connection.CreateCommand();
            command.CommandText = sqlCommandText;
            command.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();

            using (IDataReader dataReader = command.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }

            this.connection.Close();

            return dataTable;
        }
    }
}

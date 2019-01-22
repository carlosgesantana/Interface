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
        private readonly IDbConnection connection;

        public ConexaoDados(IDbConnection connection)
        {
            this.connection = connection;
        }

        public DataTable Consultar(DbCommand dbCommand, List<DbParameter> dbParameterList)
        {
            connection.Open();

            dbCommand = ConfigurarCommand(dbCommand, dbParameterList);

            DataTable dataTable = new DataTable();

            using (IDataReader dataReader = dbCommand.ExecuteReader())
            {
                dataTable.Load(dataReader);
            }

            dbCommand.Dispose();

            connection.Close();

            return dataTable;
        }

        public void Executar(DbCommand dbCommand, List<DbParameter> dbParameterList)
        {
            connection.Open();

            dbCommand = ConfigurarCommand(dbCommand, dbParameterList);

            dbCommand.ExecuteNonQuery();

            dbCommand.Dispose();

            connection.Close();
        }

        private DbCommand ConfigurarCommand(DbCommand dbCommand, List<DbParameter> dbParameterList)
        {
            dbCommand.Connection = (DbConnection)connection;

            if (dbParameterList != null && dbCommand.Parameters.Count == 0)
                dbCommand.Parameters.AddRange(dbParameterList.ToArray());

            return dbCommand;
        }
    }
}

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

            DataTable dataTable = new DataTable();

            using (dbCommand = ConfigurarCommand(dbCommand, dbParameterList))
            {
                IDataReader dataReader = dbCommand.ExecuteReader();
                dataTable.Load(dataReader);
            }

            connection.Close();

            return dataTable;
        }

        public void Executar(DbCommand dbCommand, List<DbParameter> dbParameterList)
        {
            connection.Open();

            using (dbCommand = ConfigurarCommand(dbCommand, dbParameterList))
            {
                dbCommand.ExecuteNonQuery();
            }

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

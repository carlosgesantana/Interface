using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace QuePerigo.Dados
{
    public interface IConexaoDados
    {
        DataTable Consultar(DbCommand dbCommand, List<DbParameter> dbParameterList);
        void Executar(DbCommand dbCommand, List<DbParameter> dbParameterList);
    }
}
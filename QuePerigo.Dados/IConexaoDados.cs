namespace QuePerigo.Dados
{
    public interface IConexaoDados
    {
        System.Data.DataTable Consultar(string sqlCommandText);
    }
}
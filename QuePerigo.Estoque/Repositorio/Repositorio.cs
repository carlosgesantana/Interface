using System;
using QuePerigo.Dados;

namespace QuePerigo.Repositorio
{
    public class Repositorio
    {
        protected readonly IConexaoDados conexaoDados;

        public Repositorio(Dados.IConexaoDados conexaoDados)
        {
            this.conexaoDados = conexaoDados;
        }
    }
}

using System;
using QuePerigo.Dados;

namespace QuePerigo.Repositorio
{
    public class Repositorio
    {
        protected readonly IConexaoDados bdEstoque;

        public Repositorio(Dados.IConexaoDados conexaoDados)
        {
            this.bdEstoque = conexaoDados;
        }
    }
}

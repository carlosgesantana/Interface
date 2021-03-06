﻿using QuePerigo.Estoque.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace QuePerigo.Repositorio
{
    public class ProdutoRepositorio : Repositorio
    {
        public ProdutoRepositorio(Dados.IConexaoDados conexaoDados) : base(conexaoDados)
        {

        }

        public List<Produto> GetProdutos(string descricaoCurta)
        {
            List<Produto> produtos = new List<Produto>();

            if (!string.IsNullOrEmpty(descricaoCurta))
            {
                DataTable dataTable = conexaoDados.Consultar("SELECT ID_PROD FROM TBL_Produtos WHERE DESC_CURTA='" + descricaoCurta + "'");

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    Produto produto = new Produto() { Id = (int)row["ID_PROD"] };
                    produtos.Add(produto);
                }
            }

            return produtos;
        }
    }
}

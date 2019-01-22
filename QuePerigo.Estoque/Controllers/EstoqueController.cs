using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuePerigo.Dados;
using QuePerigo.Estoque.Models;
using QuePerigo.Repositorio;

namespace QuePerigo.Estoque.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly IProdutoRepositorio produtoRepositorio;
        private readonly IFornecedorRepositorio fornecedorRepositorio;
        private readonly IDominioFactory dominioFactory;

        public EstoqueController(IProdutoRepositorio produtoRepositorio, IFornecedorRepositorio fornecedorRepositorio, IDominioFactory dominioFactory)
        {
            this.produtoRepositorio = produtoRepositorio;
            this.fornecedorRepositorio = fornecedorRepositorio;
            this.dominioFactory = dominioFactory;
        }

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            Produto produto = new Produto();

            List<Fornecedor> fornecedores = fornecedorRepositorio.GetFornecedores();
            ViewBag.Fornecedores = fornecedores;

            ViewBag.Unidades = dominioFactory.GetDominio("Unidade");
            ViewBag.Situacoes = dominioFactory.GetDominio("Situacao");
            ViewBag.Origens = dominioFactory.GetDominio("Origem");
            ViewBag.Tipos = dominioFactory.GetDominio("TipoItem");
            ViewBag.Condicoes = dominioFactory.GetDominio("Condicao");

            return PartialView(produto);
        }

        [HttpPost]
        public IActionResult Formulario(Produto produto)
        {
            IList<Fornecedor> fornecedores = new List<Fornecedor>();

            fornecedores.Add(new Fornecedor() { Id = 1, Nome = "IMS" });
            fornecedores.Add(new Fornecedor() { Id = 2, Nome = "Circuit" });

            ViewBag.Fornecedores = fornecedores;

            return PartialView(produto);
        }

        public JsonResult Resultados(string descricaoCurta)
        {
            List<Produto> produtos = produtoRepositorio.GetProdutos(descricaoCurta);

            foreach (Produto produto in produtos)
            {
                produto.Fornecedor = fornecedorRepositorio.GetFornecedorFromId(produto.Fornecedor.Id);
            }

            JsonResult jsonResult = Json(produtos);

            return jsonResult;
        }


        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            produto.Fornecedor = fornecedorRepositorio.GetFornecedorFromId(produto.Fornecedor.Id);

            produto.Id = produto.Id + produto.Fornecedor.Nome;

            produto.Preco = 1.3M * produto.Custo;

            produtoRepositorio.Salvar(produto);

            return View(produto);
        }

    }
}
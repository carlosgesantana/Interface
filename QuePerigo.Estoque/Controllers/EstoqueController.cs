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
        public IProdutoRepositorio ProdutoRepositorio { get; }

        public EstoqueController(IProdutoRepositorio produtoRepositorio)
        {
            this.ProdutoRepositorio = produtoRepositorio;
        }

        public IActionResult Default()
        {
            return View();
        }

        public IActionResult Formulario()
        {
            Produto produto = new Produto();

            IList<Fornecedor> fornecedores = new List<Fornecedor>();

            fornecedores.Add(new Fornecedor() { Id = 1, Nome = "IMS" });
            fornecedores.Add(new Fornecedor() { Id = 2, Nome = "Circuit" });

            ViewBag.Fornecedores = fornecedores;

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
            List<Produto> produtos = ProdutoRepositorio.GetProdutos(descricaoCurta);
            
            JsonResult jsonResult = Json(produtos);

            return jsonResult;
        }



        public IActionResult Cadastrar(Produto produto)
        {
            return View(produto);
        }

    }
}
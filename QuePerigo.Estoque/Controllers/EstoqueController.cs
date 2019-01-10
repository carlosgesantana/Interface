using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuePerigo.Estoque.Models;

namespace QuePerigo.Estoque.Controllers
{
    public class EstoqueController : Controller
    {
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
        public IActionResult Formulario(string descricaoCurta)
        {
            Produto produto = new Produto() { DescricaoCurta = descricaoCurta, Fornecedor = new Fornecedor() { Id = 2, Nome = "Circuit" } };

            IList<Fornecedor> fornecedores = new List<Fornecedor>();

            fornecedores.Add(new Fornecedor() { Id = 1, Nome = "IMS" });
            fornecedores.Add(new Fornecedor() { Id = 2, Nome = "Circuit" });

            ViewBag.Fornecedores = fornecedores;

            return PartialView(produto);
        }

        public IActionResult Cadastrar(Produto produto)
        {
            return View(produto);
        }

    }
}
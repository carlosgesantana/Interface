using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuePerigo.Estoque.Controllers;
using QuePerigo.Estoque.Models;
using QuePerigo.Repositorio;
using System.Collections.Generic;

namespace QuePerigo.Testes
{
    [TestClass]
    public class EstoqueControllerTestes
    {
        public EstoqueControllerTestes()
        {


        }

        [TestMethod]
        public void Teste_FormularioNovoProduto_Erro_Vazio()
        {
            //Arrange
            Mock<IProdutoRepositorio> mockProduto = new Mock<IProdutoRepositorio>();
            IProdutoRepositorio produtoRepositorio = mockProduto.Object;

            Mock<IFornecedorRepositorio> mockFornecedor = new Mock<IFornecedorRepositorio>();
            IFornecedorRepositorio fornecedorRepositorio = mockFornecedor.Object;

            IDominioFactory dominioFactory = new DominioFactory();

            EstoqueController estoqueController = new EstoqueController(produtoRepositorio, fornecedorRepositorio, dominioFactory);

            mockFornecedor.Setup(x => x.GetFornecedores()).Returns(() => new List<Fornecedor>());

            //Assert
            var ex = Assert.ThrowsException<FornecedorException>(() => estoqueController.Formulario());

            Assert.AreEqual("Nenhum fornecedor está cadastrado!", ex.Message);
            mockFornecedor.Verify(x => x.GetFornecedores(), Times.Once);
        }

        [TestMethod]
        public void Teste_FormularioNovoProduto_Erro_Nulo()
        {
            //Arrange
            Mock<IProdutoRepositorio> mockProduto = new Mock<IProdutoRepositorio>();
            IProdutoRepositorio produtoRepositorio = mockProduto.Object;

            Mock<IFornecedorRepositorio> mockFornecedor = new Mock<IFornecedorRepositorio>();
            IFornecedorRepositorio fornecedorRepositorio = mockFornecedor.Object;

            IDominioFactory dominioFactory = new DominioFactory();

            EstoqueController estoqueController = new EstoqueController(produtoRepositorio, fornecedorRepositorio, dominioFactory);

            mockFornecedor.Setup(x => x.GetFornecedores()).Returns(() => null);

            //Assert
            var ex = Assert.ThrowsException<FornecedorException>(() => estoqueController.Formulario());

            Assert.AreEqual("Nenhum fornecedor está cadastrado!", ex.Message);
            mockFornecedor.Verify(x => x.GetFornecedores(), Times.Once);
        }

        [TestMethod]
        public void Teste_FormularioNovoProduto_Sucesso()
        {
            //Arrange
            Mock<IProdutoRepositorio> mockProduto = new Mock<IProdutoRepositorio>();
            IProdutoRepositorio produtoRepositorio = mockProduto.Object;

            Mock<IFornecedorRepositorio> mockFornecedor = new Mock<IFornecedorRepositorio>();
            mockFornecedor.Setup(x => x.GetFornecedores()).Returns(() => new List<Fornecedor> { new Fornecedor() });
            IFornecedorRepositorio fornecedorRepositorio = mockFornecedor.Object;

            IDominioFactory dominioFactory = new DominioFactory();

            EstoqueController estoqueController = new EstoqueController(produtoRepositorio, fornecedorRepositorio, dominioFactory);
            estoqueController.Formulario();


            //Assert
            mockFornecedor.Verify(x => x.GetFornecedores(), Times.Once);
        }
    }
}

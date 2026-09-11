using LojaMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaMVCTests
{
    public class ProdutoTests
    {
        [Fact]
        public void ValorProduto_Maior_que_Zero()
        {
            //Arrange
            var produto = new Produto
            {
                Nome = "Mouse",
                Preco = 0,
                Estoque = 100
            };
            //Act

            var resultado = produto.Validation();
            //Assert
            Assert.False(resultado);
            
        }
        [Fact]
        public void Estoque_Invalido_Quando_For_Negativo()
        {
            var produto = new Produto
            {
                Nome = "Teclado",
                Preco = 200,
                Estoque = -5
            };
            var resultado = produto.Validation();
            Assert.False(resultado);
        }
        [Fact]
        public void Nome_Invalido_Se_Vazio_Ou_Nulo()
        {
            var produto = new Produto
            {
                Nome = "",
                Preco = 10,
                Estoque = 98
            };

            var resultado = produto.Validation();

            Assert.False(resultado);
        }

        [Fact]
        public void VerificaNome_Valido_VerificaPreco_Valido_VerificaEstoque_Valido()
        {
            var produto = new Produto
            {
                Nome = "Monitor",
                Preco = 10,
                Estoque = 98
            };

            var resultado = produto.Validation();

            Assert.True(resultado);
        }
    }
}

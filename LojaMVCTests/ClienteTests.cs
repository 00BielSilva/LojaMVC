using LojaMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LojaMVCTests
{
    public class ClienteTests
    {
        [Fact]
        public void Idade_Menor_Que_18_Invalida()
        {
            var cliente = new Cliente
            {
               
                Nome = "Robertin",
                Email = "robertin@gmail.com",
                Idade = 14,
                Ativo = true
            };

            var resultado = cliente.Validation();
            Assert.False(resultado);
        }
        [Fact]
        public void Verifica_Email_Invalido()
        {
            var cliente = new Cliente
            {
              
                Nome = "Robertin",
                Email = "robertingmail.com",
                Idade = 20,
                Ativo = true
            };
            var resultado = cliente.Validation();
            Assert.False(resultado);
        }
        [Fact]

        public void Verifica_Cliente_Sem_nome_Invalido()
        {
            var cliente = new Cliente
            {

                Nome = "",
                Email = "robertin@gmail.com",
                Idade = 20,
                Ativo = true
            };
            var resultado = cliente.Validation();
            Assert.False(resultado);
        }
        [Fact]
        public void Verifica_Cliente_Inativo_Nao_Faz_Compras()
        {
            var cliente = new Cliente
            {

                Nome = "Robertin",
                Email = "robertin@gmail.com",
                Idade = 20,
                Ativo = false
            };
            var resultado = cliente.Permission() && cliente.Validation();
            Assert.False(resultado);
        }
        [Fact]
        public void Verifica_Cliente_Pode_Comprar_Se_Maior_de_Idade_E_Ativo()
        {
            var cliente = new Cliente
            {

                Nome = "Robertin",
                Email = "robertin@gmail.com",
                Idade = 20,
                Ativo = true
            };
            var resultado = cliente.Validation() && cliente.Permission();
            Assert.True(resultado);
        }
    }
}

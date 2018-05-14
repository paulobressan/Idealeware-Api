using System;
using System.Collections.Generic;
using System.Text;

namespace Idealeware.Service.Models
{
    public class Produto
    {
        public Produto()
        {
            this.Ativo = true;
        }

        public Produto(string nome, decimal valorCompra, decimal valorVenda, Categoria categoria)
        {
            this.Nome = nome;
            this.ValorCompra = valorCompra;
            this.ValorVenda = valorVenda;
            this.Categoria = categoria;
            this.Ativo = true;
        }
        
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorCompra { get; private set; }
        public decimal ValorVenda { get; private set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public bool Ativo { get; set; }

        public decimal SetValorCompra(decimal valor)
        {
            this.ValorCompra = valor >= 0 ? valor : 0;
            return this.ValorCompra;
        }

        public decimal SerValorVenda(decimal valor)
        {
            this.ValorVenda = valor >= 0 ? valor : 0;
            return this.ValorVenda;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Idealeware.Service.Models
{
    public class Categoria
    {
        public Categoria()
        {
            this.Ativo = true;
        }
        public Categoria(string nome)
        {
            this.Nome = nome;
            this.Ativo = true;
        }

        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}

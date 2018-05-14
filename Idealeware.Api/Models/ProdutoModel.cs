using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Idealeware.Service.Models
{
    public class ProdutoModel
    {
        public int IdProduto { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public decimal ValorCompra { get; set; }
        [Required]
        public decimal ValorVenda { get; set; }
        
    }
}

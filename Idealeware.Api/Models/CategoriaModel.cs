using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Idealeware.Service.Models
{
    public class CategoriaModel
    {
        public int IdCategoria { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}

using Idealeware.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idealeware.Service.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Select();
        Task<Produto> SelectById(int id);
        Task<IEnumerable<Produto>> SelectByCategoriaId(int id);
        Task<Produto> Insert(Produto produto);
        Task<Produto> Update(Produto produto);
        Task<int> Remove(int id);
    }
}

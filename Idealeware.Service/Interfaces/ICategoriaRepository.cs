using Idealeware.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idealeware.Service.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Select();
        Task<Categoria> SelectById(int id);
        Task<Categoria> Insert(Categoria categoria);
        Task<Categoria> Update(Categoria categoria);
        Task<int> Remove(int id);
        Task<int> Inactivate(int id);
    }
}

using Dapper;
using Idealeware.Service.Interfaces;
using Idealeware.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idealeware.Service.Repository
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        public async Task<int> Remove(int id)
        {
            await context.QueryAsync<int>(@"delete from categoria where idCategoria = @id", new { id });
            return id;
        }

        public async Task<Categoria> Insert(Categoria categoria)
        {
            var result = await context.QueryAsync<Categoria>(@"insert into categoria(nome, descricao, ativo) value (@nome, @descricao, @ativo);
                                                     select idCategoria, nome, descricao,ativo from categoria where idCategoria = (SELECT LAST_INSERT_ID() as idCategoria);", categoria);
            return result.SingleOrDefault();
        }

        public async Task<Categoria> Update(Categoria categoria)
        {
            var result = await context.QueryAsync<Categoria>(@"update categoria set nome = @nome, descricao = @descricao, ativo = @ativo where idCategoria = @idCategoria;
                                                                   select idCategoria, nome, descricao,ativo from categoria where idCategoria = @idCategoria;", categoria);
            return result.SingleOrDefault();
        }
        
        public async Task<Categoria> SelectById(int id)
        {
            var result = await context.QueryAsync<Categoria>(@"select idCategoria, nome, descricao,ativo
                                       from categoria where idCategoria = @id;", new { id });
            return result.SingleOrDefault();
        }

        public async Task<IEnumerable<Categoria>> Select()
        {
            var result = await context.QueryAsync<Categoria>(@"select idCategoria, nome, descricao,ativo
                                       from categoria;", null);
            return result.ToList();
        }

        public async Task<int> Inactivate(int id)
        {
            await context.QueryAsync<int>(@"update categoria set ativo = 0 where idCategoria = @id", new { id });
            return id;
        }
    }
}

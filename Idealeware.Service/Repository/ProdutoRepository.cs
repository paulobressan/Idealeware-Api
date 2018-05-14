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
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public async Task<int> Remove(int id)
        {
            await context.QueryAsync<int>(@"delete from produto where idProduto = @id", new { id });
            return id;
        }

        public async Task<Produto> SelectById(int id)
        {
            var result = await context.QueryAsync<Produto, Categoria, Produto>(@"select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
                inner join categoria c on p.idCategoria = c.idCategoria where p.idProduto = @id and c.ativo = 1;", (produto, categoria) =>
            {
                produto.Categoria = categoria;
                return produto;
            }, new { id }, splitOn: "idCategoria");
            return result.SingleOrDefault();
        }

        public async Task<IEnumerable<Produto>> Select()
        {
            var result = await context.QueryAsync<Produto, Categoria, Produto>(@"select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
                inner join categoria c on p.idCategoria = c.idCategoria where c.ativo = 1;", (produto, categoria) =>
            {
                produto.Categoria = categoria;
                return produto;
            }, null, splitOn: "idCategoria");
            return result.ToList();
        }

        public async Task<Produto> Insert(Produto produto)
        {
            var result = await context.QueryAsync<Produto, Categoria, Produto>(@"insert into produto(idCategoria ,nome, descricao, valorCompra, valorVenda, ativo)
                values (@idCategoria ,@nome, @descricao, @valorCompra, @valorVenda, @ativo);
                select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
                inner join categoria c on p.idCategoria = c.idCategoria where p.idProduto = (SELECT LAST_INSERT_ID() as idCategoria);", (produtoI, categoria) =>
            {
                produtoI.Categoria = categoria;
                return produtoI;
            }, produto, splitOn: "idCategoria");
            return result.SingleOrDefault();
        }

        public async Task<Produto> Update(Produto produto)
        {
            var result = await context.QueryAsync<Produto, Categoria, Produto>(@"update produto set idCategoria = @idCategoria, nome = @nome, descricao = @descricao, valorCompra = @valorCompra, valorVenda = @valorVenda, ativo = @ativo
                where idProduto = @idProduto;
                select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
                inner join categoria c on p.idCategoria = c.idCategoria where p.idProduto = @idProduto;", (produtoI, categoria) =>
            {
                produtoI.Categoria = categoria;
                return produtoI;
            }, produto, splitOn: "idCategoria");
            return result.SingleOrDefault();
        }

        public async Task<IEnumerable<Produto>> SelectByCategoriaId(int id)
        {
            var result = await context.QueryAsync<Produto, Categoria, Produto>(@"select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
                inner join categoria c on p.idCategoria = c.idCategoria where c.idCategoria = @id and c.ativo = 1;", (produto, categoria) =>
            {
                produto.Categoria = categoria;
                return produto;
            }, new { id }, splitOn: "idCategoria");
            return result.ToList();
        }
    }
}

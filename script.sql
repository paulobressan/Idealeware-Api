create database idealeware;
use idealeware;

create table categoria (
  idCategoria int unsigned auto_increment primary key,
  nome varchar(100) not null ,
  descricao varchar(255),
  ativo bool
);

create table produto(
  idProduto int unsigned auto_increment primary key ,
  idCategoria int unsigned,
  nome varchar(100) not null ,
  descricao varchar(255),
  valorCompra decimal(12,2) not null ,
  valorVenda decimal(12,2) not null ,
  ativo bool,
  foreign key (idCategoria) references categoria(idCategoria)
);

select * from categoria;

select idCategoria, nome, descricao,ativo from categoria where idCategoria = (SELECT LAST_INSERT_ID() as idCategoria);
insert into categoria(nome, descricao, ativo) value ('Teste', 'Teste2', 1); SELECT LAST_INSERT_ID() as idCategoria;

update categoria set nome = @nome, descricao = @descricao, ativo = @ativo where idCategoria = @idCategoria;
select idCategoria, nome, descricao,ativo from categoria where idCategoria = (SELECT LAST_INSERT_ID() as idCategoria);

select idCategoria, nome, descricao,ativo
                                       from categoria;

select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
inner join categoria c on p.idCategoria = c.idCategoria;

insert into produto(idCategoria ,nome, descricao, valorCompra, valorVenda, ativo)
  values (@idCategoria ,@nome, @descricao, @valorCompra, @valorVenda, @ativo);
select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
inner join categoria c on p.idCategoria = c.idCategoria where p.idProduto = (SELECT LAST_INSERT_ID() as idCategoria);

update produto set idCategoria = @idCategoria, nome = @nome, descricao = @descricao, valorCompra = @valorCompra, valorVenda = @valorVenda, ativo = @ativo
  where idProduto = @idProduto;
select p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.ativo, c.idCategoria, c.nome, c.descricao, c.ativo from produto p
inner join categoria c on p.idCategoria = c.idCategoria where p.idProduto = @idProduto;

delete from produto where idProduto = @idProduto

delete from produto where idProduto = 2;

update categoria set ativo = 1 where idCategoria = 1;
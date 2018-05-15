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

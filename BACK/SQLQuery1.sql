use master  
go

if(exists(select * from sys.databases where name = 'PodraoDb'))
	drop database PodraoDb
go

create database PodraoDb
go

use PodraoDb
go


create table Produto(
	ID int identity primary key,
	NomeProduto varchar(200) not null,
	Foto varbinary(MAX) null, 
	Preco decimal(5,2) not null,
	DescricaoProduto varchar(400) not null
);
go

create table Promocao(
	ID int identity primary key,
	NomePromocao varchar(80) not null,
	Foto varbinary(MAX) null, 
	DescricaoPromocao varchar(400) not null,
	Preco decimal(5,2) not null,
	ProdutoID int references Produto(ID) not null
);
go

create table Cardapio(
	ID int identity primary key,
	ProdutoID int references Produto(ID) not null
);
go

create table Adm(
	ID int identity primary key,
	Nome varchar(200) not null,
	Email varchar(200) not null,
	Cpf varchar(20) not null,
	Senha varchar(20) not null,
	Genero varchar(20) not null,
	TipoUsuario varchar(100) not null
);
go

create table Totem(
	ID int identity primary key,
	CardapioID int references Cardapio(ID) not null,
	PromocaoID int references Promocao(ID) not null
);
go

create table Imagem(
	ID int identity primary key,
	Foto varbinary(MAX) not null
);
go

create table Cliente(
	ID int identity primary key,
	Nome varchar(200) not null,
	Email varchar(200) not null,
	Cpf varchar(20) not null,
	Senha varchar(MAX) not null,
	Salt varchar(200) not null,
	Genero varchar(20) not null,
	TipoUsuario varchar(100) not null,
	TerminodoPedido datetime null,
	ImagemID int references Imagem(ID)
);
go

create table Perfil(
	ID int identity primary key,
	UsuarioID int references Cliente(ID) not null,
	ImagemID int references Imagem(ID) not null
);


create table Pedido(
	ID int identity primary key,
	ClienteID int references Cliente(ID) not null,
	PromocaoID int references Promocao(ID) not null,
	ProdutoID int references Produto(ID) not null,
	EntregadoPedido datetime null
);
go

create table PedidodoCliente(
	ID int identity primary key,	
	ClienteId int references Cliente(ID) not null,
	PedidoID int references Pedido(ID) not null
);
go


 
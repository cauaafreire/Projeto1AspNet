-- CRIANDO O BANCO DE DADOS
CREATE DATABASE bdProjeto1;

-- USANDO O BANCO DE DADOS 
USE bdProjeto1;

-- CRIANDO AS TABELAS D BANCO DE DADOS
CREATE TABLE Usuario(
	Id int primary key auto_increment,
    Nome varchar(40) not null,
    Email varchar(40) not null,
    Senha varchar(40)not null
);


CREATE TABLE Produtos (
	CodProd int primary key auto_increment,
    Nome varchar(40) not null,
    Descricao mediumtext not null,
    Preco int not null,
    Quantidade int not null
);

-- CONSULTANDO AS TABELAS DO BANCO DE DADOS
SELECT * FROM Usuario;
SELECT * FROM Produtos;

insert into Usuario(Nome,Email,Senha) values ('admin','admin@email.com',123456);
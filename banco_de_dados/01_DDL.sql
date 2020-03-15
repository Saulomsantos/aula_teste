-- Cria o banco de dados
CREATE DATABASE Aula_teste;
GO

-- Define o uso do banco de dados
USE Aula_teste;
GO

-- Cria a tabela
CREATE TABLE Usuarios(
	IdUsuario	INT PRIMARY KEY IDENTITY
	,Nome		VARCHAR (255) NOT NULL
	,Email		VARCHAR (255) NOT NULL UNIQUE
	,Senha		VARCHAR (255) NOT NULL
);
GO
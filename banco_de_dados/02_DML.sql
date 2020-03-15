-- Define o uso do banco de dados
USE Aula_teste;
GO

-- Insere dois usuários na tabela criada
INSERT INTO Usuarios(Nome, Email, Senha)
VALUES				('Usuario 1','usuario1@email.com','123'),
					('Usuario 2','usuario2@email.com','456');
GO
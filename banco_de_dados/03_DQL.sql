-- Define o uso do banco de dados
USE Aula_teste;
GO

-- Lista o nome, e-mail e a senha de todos os usuários
SELECT IdUsuario, Nome, Email, Senha FROM Usuarios;
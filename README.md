# Roteiro de aula

Roteiro de execução da aula teste a fim de explicar os conteúdos abordados.


## Tema de exemplo

Exibição de informações armazenadas em um banco de dados através de uma API.


## Resumo

- Tópicos abordados;
- Desenvolvimento da explicação;
- Resumo dos conteúdos explicados;
- Dúvidas;
- Disponibilizar conteúdo de aula;

## Tópicos que serão abordados na aula

- Contexto de um sistema web, fazendo a ligação entre front-end, back-end (API) e banco de dados;
    
- Estrutura de um banco de dados criado, utilizando SQL Server;
  
- Estrutura do back-end criado, usando a interface de programação API em C#;
  
- Consumo das informações através de uma plataforma de teste de requisições (Postman);
  
  
## Explicar os conceitos, exemplificando com prática

### Banco de dados

#### Mostrar no Sql Server Managemente Studio os scripts (DDL, DML e DQL) criados para gerar o banco de dados.

##### DDL

```sql
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
```

##### DML

```sql
-- Define o uso do banco de dados
USE Aula_teste;
GO

-- Insere dois usuários na tabela criada
INSERT INTO Usuarios(Nome, Email, Senha)
VALUES              ('Usuario 1','usuario1@email.com','123'),
                    ('Usuario 2','usuario2@email.com','456');
GO
```

##### DQL

```sql
-- Define o uso do banco de dados
USE Aula_teste;
GO

-- Lista o nome, e-mail e a senha todos os usuários
SELECT IdUsuario, Nome, Email, Senha FROM Usuarios;
```

### Back-End

#### Mostrar no Visual Studio o endpoint desenvolvido que recebe a requisição.

```c#
/// <summary>
/// String de conexão com o banco de dados que recebe os parâmetros
/// </summary>
private string stringConexao = "Data Source=DESKTOP-NJ6LHN1\\SQLDEVELOPER; initial catalog=Aula_teste; integrated security=true;";

/// <summary>
/// Lista todos os usuários
/// </summary>
/// <returns>Uma lista de usuários</returns>
/// dominio/api/Usuarios
[HttpGet]
public IActionResult Get()
{
    // Cria uma lista de usuários nomeada listaUsuarios
    List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

    // Declara a SqlConnection passando a string de conexão
    using (SqlConnection con = new SqlConnection(stringConexao))
    {
        // Declara a instrução a ser executada
        string querySelectAll = "SELECT IdUsuario, Nome, Email FROM Usuarios";

        // Abre a conexão com o banco de dados
        con.Open();

        // Declara o SqlDataReader para receber os dados do banco de dados
        SqlDataReader rdr;

        // Declara o SqlCommand passando o comando a ser executado e a conexão
        using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
        {
            // Executa a query e armazena os dados no rdr
            rdr = cmd.ExecuteReader();

            // Enquanto houver registros para serem lidos no rdr, o laço se repete
            while (rdr.Read())
            {
                // Instancia um objeto usuario 
                UsuarioDomain usuario = new UsuarioDomain
                {
                    // Atribui às propriedades os valores das colunas da tabela do banco
                    IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                    Nome = rdr["Nome"].ToString(),
                    Email = rdr["Email"].ToString()
                };

                // Adiciona o usuario criado à lista listaUsuarios
                listaUsuarios.Add(usuario);
            }
        }
    }

    // Retorna a lista de usuários com um status code 200 - Ok
    return Ok(listaUsuarios);
}
```

#### Testar a requisição através do Postman

http://localhost:5000/api/Usuarios

<img src="https://github.com/saulomsantos/aula_teste/blob/master/imagens/roteiro_exemplo_response.png" />



## Resumir o conteúdo explicado

Relembrar o contexto do sistema web, onde a plataforma Postman simulou o cliente da aplicação, o banco de dados foi a fonte de informações e o back-end foi o responsável por buscar essas informações, de maneira controlada e segura; 
 
 
## Dúvidas

Abrir espaço para perguntas;

## Disponibilizar este roteiro




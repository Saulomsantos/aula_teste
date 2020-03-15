using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Aula.teste.WebApi.Domains;
using Microsoft.AspNetCore.Mvc;

namespace Aula.teste.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos usuários
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
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
    }
}
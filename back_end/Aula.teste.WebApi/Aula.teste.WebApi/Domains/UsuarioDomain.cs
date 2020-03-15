namespace Aula.teste.WebApi.Domains
{
    /// <summary>
    /// Classe responsável pela entidade Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
    }
}

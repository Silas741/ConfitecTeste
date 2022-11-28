namespace Confitec.Identidade.API.Models
{
    public class UsuarioTokenModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UsuarioClaim> Claims { get; set; }
    }
}

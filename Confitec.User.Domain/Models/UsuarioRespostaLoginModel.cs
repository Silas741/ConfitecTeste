namespace Confitec.Identidade.API.Models
{
    public class UsuarioRespostaLoginModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenModel UsuarioToken { get; set; }
    }
}

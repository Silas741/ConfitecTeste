using System.ComponentModel.DataAnnotations;

namespace Confitec.Application.Services
{
    public class UsuarioViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sobrenome { get; set; }
        public int Escolaridade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato invalido")]
        public string Email { get; set; }

    }
}
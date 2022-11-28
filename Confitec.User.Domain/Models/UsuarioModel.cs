using NetDevPack.Domain;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Identidade.API.Models
{
    public class UsuarioModel : Entity,IAggregateRoot
    {
        protected UsuarioModel() { }

        public UsuarioModel(Guid id,string nome, DateTime dataNascimento, int escolaridade, string email, string sobrenome)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Email = email;
            Sobrenome = sobrenome;
        }

        [StringLength(100, ErrorMessage = "O campo precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sobrenome { get; set; }
        public int Escolaridade { get; set; }

        [Required(ErrorMessage ="O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage ="O campo {0} está em formato invalido")]
        public string Email { get; set; }
    }
}

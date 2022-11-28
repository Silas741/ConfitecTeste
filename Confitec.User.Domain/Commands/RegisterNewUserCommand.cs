using Confitec.User.Domain.Commands;
using Confitec.User.Domain.Commands.Validations;

namespace Confitec.Identidade.API.Commands
{
    public class RegisterNewUserCommand : UserCommand
    {
        public RegisterNewUserCommand(string nome, DateTime dataNascimento, int escolaridade, string email, string sobrenome)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Email = email;
            Sobrenome = sobrenome;
        }

        public override bool IsValid() {
            ValidationResult = new RegisterNewUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

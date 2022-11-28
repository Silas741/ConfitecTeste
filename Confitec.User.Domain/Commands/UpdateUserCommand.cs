using Confitec.User.Domain.Commands;
using Confitec.User.Domain.Commands.Validations;
using FluentValidation.Results;

namespace Confitec.Identidade.API.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(Guid id,string nome, DateTime dataNascimento, int escolaridade, string email, string sobrenome)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            Email = email;
            Sobrenome = sobrenome;
        }

        public override bool IsValid() {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

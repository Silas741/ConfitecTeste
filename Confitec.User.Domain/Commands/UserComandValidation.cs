using Confitec.Identidade.API.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.User.Domain.Commands
{
    public abstract class UserComandValidation<T> : AbstractValidator<T> where T : UserCommand
    {
        public void Valid()
        {
            RuleFor(c => c.Nome)
                .Length(2, 250).WithMessage("O Nome precisa ter entre 2 a 250 caracteres")
                .NotEmpty().WithMessage("O Nome precisa ser fornecido");
            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .Must(VerifyYears)
                .WithMessage("Data de nascimento maior que data atual.");            
        }

        public class RegisterUserCommandValidation : UserComandValidation<RegisterNewUserCommand>
        {
            public RegisterUserCommandValidation()
            {
                Valid();
            }
        }
        public class UpdateUserCommandValidation : UserComandValidation<UpdateUserCommand>
        {
            public UpdateUserCommandValidation()
            {
                Valid();
            }
        }


        protected static bool VerifyYears(DateTime Nascimento)
        {
            return Nascimento >= DateTime.Now;
        }
    }
}

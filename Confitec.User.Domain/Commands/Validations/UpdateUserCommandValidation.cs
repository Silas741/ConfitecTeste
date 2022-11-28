using Confitec.Identidade.API.Commands;

namespace Confitec.User.Domain.Commands.Validations
{
    internal class UpdateUserCommandValidation : UserComandValidation<UpdateUserCommand>
    {
        public UpdateUserCommandValidation()
        {
            Valid();
        }
    }
}

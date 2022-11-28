using Confitec.Identidade.API.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.User.Domain.Commands.Validations
{
    public class RegisterNewUserCommandValidation : UserComandValidation<RegisterNewUserCommand>
    {
        public RegisterNewUserCommandValidation()
        {
            Valid();
        }
    }
}

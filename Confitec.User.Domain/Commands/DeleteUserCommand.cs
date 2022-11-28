using Confitec.User.Domain.Commands;
using System.ComponentModel.DataAnnotations;

namespace Confitec.Identidade.API.Commands
{
    public class DeleteUserCommand : UserCommand
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}

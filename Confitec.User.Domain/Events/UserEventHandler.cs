using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.User.Domain.Events
{
    public class UserEventHandler :
         INotificationHandler<UserUpdatedEvent>,
         INotificationHandler<UserRegisteredEvent>,
         INotificationHandler<UserRemovedEvent>
    {
        public Task Handle(UserUpdatedEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(UserRegisteredEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }

        public Task Handle(UserRemovedEvent message, CancellationToken cancellationToken)
        {

            return Task.CompletedTask;
        }
    }
}

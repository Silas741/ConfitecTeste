using NetDevPack.Messaging;

namespace Confitec.User.Domain.Events
{
    public class UserRemovedEvent : Event
    {
        public UserRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
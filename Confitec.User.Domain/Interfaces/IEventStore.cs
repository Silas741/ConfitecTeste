using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.User.Domain.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}

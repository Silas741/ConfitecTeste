using NetDevPack.Messaging;

namespace Confitec.User.Domain.Events
{
    public class UserRegisteredEvent : Event
    {
        public UserRegisteredEvent(Guid id, string nome, DateTime dataNascimento, string sobrenome, int escolaridade, string email)
        {
            Id = id;
            Nome = nome;
            DataNascimento = dataNascimento;
            Sobrenome = sobrenome;
            Escolaridade = escolaridade;
            Email = email;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sobrenome { get; set; }
        public int Escolaridade { get; set; }
        public string Email { get; set; }
    }
}
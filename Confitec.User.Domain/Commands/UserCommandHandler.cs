using Confitec.Identidade.API.Commands;
using Confitec.Identidade.API.Models;
using Confitec.User.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NetDevPack.Messaging;
using Confitec.User.Domain.Events;

namespace Confitec.User.Domain.Commands
{
    public class UserCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUserCommand, ValidationResult>,
        IRequestHandler<UpdateUserCommand, ValidationResult>,
        IRequestHandler<DeleteUserCommand, ValidationResult>
    {
        private readonly IUserRepository _UserRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new UsuarioModel(Guid.NewGuid(), message.Nome, message.DataNascimento,message.Escolaridade, message.Email,message.Sobrenome);

            if (await _UserRepository.GetByEmail(user.Email) != null)
            {
                AddError("Email já cadastrado.");
                return ValidationResult;
            }

            user.AddDomainEvent(new UserRegisteredEvent(user.Id, user.Nome,user.DataNascimento, user.Sobrenome, user.Escolaridade,user.Email));

            _UserRepository.Add(user);

            return await Commit(_UserRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(UpdateUserCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var user = new UsuarioModel(message.Id,message.Nome, message.DataNascimento, message.Escolaridade, message.Email, message.Sobrenome);
            var existingUser = await _UserRepository.GetByEmail(user.Email);

            if (existingUser != null && existingUser.Id != user.Id)
            {
                if (!existingUser.Equals(user))
                {
                    AddError("The customer e-mail has already been taken.");
                    return ValidationResult;
                }
            }

            user.AddDomainEvent(new UserUpdatedEvent(user.Id,user.Nome, user.DataNascimento, user.Sobrenome, user.Escolaridade, user.Email));

            _UserRepository.Update(user);

            return await Commit(_UserRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(DeleteUserCommand message, CancellationToken cancellationToken)
        {

            var user = await _UserRepository.GetById(message.Id);

            if (user is null)
            {
                AddError("Usuario não existe.");
                return ValidationResult;
            }

            user.AddDomainEvent(new UserRemovedEvent(message.Id));

            _UserRepository.Remove(user);

            return await Commit(_UserRepository.UnitOfWork);
        }
    }
}

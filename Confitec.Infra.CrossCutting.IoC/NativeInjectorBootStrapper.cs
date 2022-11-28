using Confitec.Application.Interfaces;
using Confitec.Application.Services;
using Confitec.Identidade.API.Commands;
using Confitec.Infra.CrossCutting.Bus;
using Confitec.Infra.Data.Context;
using Confitec.Infra.Data.Repository;
using Confitec.User.Domain.Commands;
using Confitec.User.Domain.Events;
using Confitec.User.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Confitec.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUserService, UserServices>();

            // Domain - Events
            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, ValidationResult>, UserCommandHandler>();

            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AplicationDbContext>();
        }
    }
}
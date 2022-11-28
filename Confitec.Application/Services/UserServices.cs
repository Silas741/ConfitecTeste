using AutoMapper;
using Confitec.Application.Interfaces;
using Confitec.Identidade.API.Commands;
using Confitec.Identidade.API.Models;
using Confitec.User.Domain.Interfaces;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Services
{
    public class UserServices : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IUserRepository _userRepository;

        public UserServices(IMapper mapper, IMediatorHandler mediator, IUserRepository userRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _userRepository.GetAll());
        }

        public async Task<UsuarioViewModel> GetById(Guid? id)
        {
            return _mapper.Map<UsuarioViewModel>(await _userRepository.GetById(id.Value)) ;
        }

        public async Task<ValidationResult> Register(UsuarioViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(customerViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(UsuarioViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid? id)
        {
            var removeCommand = new DeleteUserCommand(id.Value);
            return await _mediator.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

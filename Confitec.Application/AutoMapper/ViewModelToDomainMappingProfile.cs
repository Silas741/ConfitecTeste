using AutoMapper;
using Confitec.Application.Services;
using Confitec.Identidade.API.Commands;
using Confitec.Identidade.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, RegisterNewUserCommand>()
                .ConstructUsing(c => new RegisterNewUserCommand(c.Nome,c.DataNascimento,c.Escolaridade, c.Email, c.Sobrenome));
            CreateMap<UsuarioViewModel, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id,c.Nome, c.DataNascimento, c.Escolaridade, c.Email, c.Sobrenome));
        }
    }
}

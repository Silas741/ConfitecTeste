using AutoMapper;
using Confitec.Application.Services;
using Confitec.Identidade.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<UsuarioModel, UsuarioViewModel>();
        }
    }
}

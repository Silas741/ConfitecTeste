using Confitec.Application.Services;
using Confitec.Identidade.API.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Application.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IEnumerable<UsuarioViewModel>> GetAll();
        Task<UsuarioViewModel> GetById(Guid? id);

        Task<ValidationResult> Register(UsuarioViewModel customerViewModel);
        Task<ValidationResult> Update(UsuarioViewModel customerViewModel);
        Task<ValidationResult> Remove(Guid? id);

    }
}

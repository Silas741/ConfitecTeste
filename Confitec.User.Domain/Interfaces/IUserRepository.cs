using Confitec.Identidade.API.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.User.Domain.Interfaces
{
    public interface IUserRepository : IRepository<UsuarioModel>
    {
        Task<IEnumerable<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetByEmail(string email);
        Task<UsuarioModel> GetById(Guid id);
        void Add(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Remove(UsuarioModel usuario);
    }
}

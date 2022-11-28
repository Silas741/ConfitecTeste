using Confitec.Identidade.API.Models;
using Confitec.Infra.Data.Context;
using Confitec.User.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confitec.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly AplicationDbContext Db;

        protected readonly DbSet<UsuarioModel> DbSet;
        public UserRepository(AplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<UsuarioModel>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Add(UsuarioModel usuario)
        {
            DbSet.Add(usuario);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<UsuarioModel>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<UsuarioModel> GetByEmail(string email)
        {
            UsuarioModel? usuarioModel = await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
            return usuarioModel;
        }

        public async Task<UsuarioModel> GetById(Guid id)
        {
            UsuarioModel? usuarioModel = await DbSet.FindAsync(id);
            return usuarioModel;
        }

        public void Remove(UsuarioModel usuario)
        {
            DbSet.Remove(usuario);
        }

        public void Update(UsuarioModel usuario)
        {
            DbSet.Update(usuario);
        }
    }
}

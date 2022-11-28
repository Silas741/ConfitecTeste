using Confitec.Application.Interfaces;
using Confitec.Application.Services;
using Confitec.Identidade.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NSE.Identidade.API.Controllers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Confitec.Identidade.API.Controllers
{
    [ApiController]
    [Route("api/Auth")]
    public class AuthController : MainController
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _UserService;

        public AuthController(IOptions<AppSettings> appSettings, IUserService userService)
        {

            _appSettings = appSettings.Value;
            _UserService = userService;
        }
        [HttpPost("Novo-Usuario")]
        public async Task<ActionResult> Register(UsuarioViewModel usuario) 
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = new IdentityUser
            {
                UserName = usuario.Email,
                Email = usuario.Email,
                EmailConfirmed = true
            };
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _UserService.Register(usuario));

        }
        

        [HttpPost("Update")]
        public async Task<ActionResult> Update(UsuarioViewModel usuario)
        {
            if (!ModelState.IsValid) return BadRequest();
            var user = await _UserService.GetById(usuario.Id);
            if (usuario == null) return NotFound();

            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _UserService.Update(usuario));

        }
        [HttpPost("Remove/{id:guid}")]
        public async Task<ActionResult> Remove(Guid? id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var usuario = await _UserService.GetById(id);
            if (usuario == null) return NotFound();

            await _UserService.Remove(id);

            return CustomResponse();

        }
        [HttpPost("All")]
        public async Task<ActionResult> GetAll()
        {
            var usuario = await _UserService.GetAll();

            return CustomResponse(usuario);

        }

    }
}

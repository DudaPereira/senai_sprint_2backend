using Hroads_webApi.Domains;
using Hroads_webApi.Interface;
using Hroads_webApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Hroads_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    // http://localhost:5000/api/logins
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginsController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(Usuario Login)
        {
            Usuario usuarioBuscado = _usuarioRepository.Login(Login.Email, Login.Senha);

            var claim = new[]
            {
                new Claim (JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim (JwtRegisteredClaimNames.Jti, usuarioBuscado.IdTipoUsuario.ToString()),
                new Claim (ClaimTypes.Role, usuarioBuscado.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("hroads-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "Hroads_webApi",
                audience: "Hroads_webApi",
                claims: claim,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }

    }
}
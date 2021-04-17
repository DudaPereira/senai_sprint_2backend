using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using senai_filmes_webApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai_filmes_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/usuarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }



        [HttpPost]
        public IActionResult Login(UsuarioDomain login)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos!");
            }

             //define os dados que serão fornecidos no token - Payload 
            var claims = new[]
            {
                                          //TipoDaClaim, ValorDaClaim
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.permissao),
                new Claim("Claim personalizada", "Valor teste")
            };

             //define a chave de acesso ao token 
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao"));

             //define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

             //define a composiçaõ do token 
            var token = new JwtSecurityToken(
                issuer : "Filmes.webAPI",                 //emissor do token
                audience : "Filmes.webAPI",              //destinatário do token 
                claims : claims,                        //dadods definidos acima (linha 59)
                expires: DateTime.Now.AddMinutes(30),  //tempo de expiração
                signingCredentials : creds            //credenciais do token 
            );

             //retornar um status code 200 - Ok com o token criado
            return Ok(new
            {
                 //gera o token 
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

           
        }
    }
}


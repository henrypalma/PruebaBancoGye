using Application.Interfaces;
using Application.Interfaces.Seguridad;
using Microsoft.Extensions.Options;
using Domain.Configuraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Authenticate;
using Domain.Repositorios;
using System.Security.Claims;
using Domain.Entidades;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Servicios.Seguridad
{
    public class AuthenticateServicio(IUsuarioVendedorRepositorio usuarioVendedorRepositorio, IOptions<JwtSettings> jwtSettings): IAuthenticateServicio
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public async Task<TokenDto> AuthenticateLogin(LoginDto request)
        {
            var usuario = await usuarioVendedorRepositorio.ConsultarPorLogin(request.Login);


            if (usuario == null)
                throw new ApplicationException("Usuario no existe");

            if (usuario.Contrasenia != request.Password)
                throw new ApplicationException("Clave Incorrecta");

            var token = GenerateToken(usuario);

            return new TokenDto
            {
                IdUsuario = usuario.Id,
                Login = usuario.Usuario!,
                Token = token
            };
        }

        private string GenerateToken(UsuarioVendedor usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Usuario!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("login", usuario.Usuario!),
            new Claim("id", usuario.Id.ToString()),

        };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

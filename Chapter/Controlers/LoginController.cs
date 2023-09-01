using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Chapter.Controlers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUsuarioRepository _iusuarioRepository;
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        [HttpPost]

        public IActionResult Login(Loginviewmodel dadosLogin)
        {
            try
            {
                Usuario usuarioBuscado = _iusuarioRepository.Login(dadosLogin.email, dadosLogin.senha);

                if (usuarioBuscado == null)
                {
                    return Unauthorized(new { msg = "Email ou senha incorreto" });

                }

                //Inicio configuração do tolken

                var minhasClains = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.id.Tostring()),

                    new Claim(ClaimTypes.Role, usuarioBuscado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(

                    issuer: "chapter.webapi",
                    audience: "chapter.webapi",
                    claims: minhasClains,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: credenciais
                    );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(meuToken) });

            }
            catch (Exception e)

            {

                throw new Exception(e.Message);
            }
        }


    }
}

using Chapter.Interfaces;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chapter.Controlers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;
        public UsuarioController (IUsuarioRepository usuarioRepository)
        {
            _iusuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iusuarioRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

    }
}

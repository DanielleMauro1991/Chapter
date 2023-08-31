using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Chapter.Controlers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
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

            [HttpGet("{id}")]

             public IActionResult BuscarPorId(int id)
            {
                try
                {
                    Usuario usuario = _iusuarioRepository.BuscarPorId(id);

                    if (usuario == null)
                    {
                        return NotFound();
                    }
                    return Ok(usuario);
                }
                catch (Exception e)
                {

                    throw;
                }
            }


        }

    }




    


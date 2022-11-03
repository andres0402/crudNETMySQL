using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETMySQL.Data.Repositories;
using NETMySQL.Model;

namespace CRUDNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public ValuesController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            return Ok(await _usuariosRepository.GetAllUsuarios());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioDetails(int id)
        {
            return Ok(await _usuariosRepository.GetUsuarioDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await _usuariosRepository.InsertUsuario(usuario);
            return Created("created", created);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           await _usuariosRepository.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _usuariosRepository.DeleteUsuario(new Usuario() { id_usuario = id });
            return NoContent();
        }


    }
}

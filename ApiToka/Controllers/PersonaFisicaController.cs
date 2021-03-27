namespace ApiToka.Controllers
{
    using ApiToka.Core.DTOs;
    using ApiToka.Core.Interfaces.Services;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaFisicaController : ControllerBase
    {
        #region Constructor
        public PersonaFisicaController(IPersonaService personaService)
        {
            this._personaService = personaService;
        }
        #endregion

        #region Atributos
        private IPersonaService _personaService;
        #endregion

        #region Métodos
        /// <summary>
        /// Obtiene el usuario en específico con base al Id enviado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpGet("ObtenerUsuarios")]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            try
            {
                var usuarioResponse = await _personaService.ObtenerPersonasFisicas();
                return Ok(usuarioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Obtiene el usuario en específico con base al Id enviado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpPost("RegistrarPersonaFisica")]
        public async Task<IActionResult> AgregarPersonaFisica([FromBody] TbPersonasFisicasDTO personasFisicasDTO)
        {
            try
            {
                var usuarioResponse = await _personaService.RegistrarPersonaFisica(personasFisicasDTO);
                return Ok(usuarioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Elimina el usuario en específico con base al Id enviado
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpDelete("BorrarPersonaFisica")]
        public async Task<IActionResult> BorrarPersonaFisica([FromQuery] int IdPersonaFisica)
        {
            try
            {
                var usuarioResponse = await _personaService.BorrarPersonaFisica(IdPersonaFisica);
                return Ok(usuarioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Actualiza la entidad que se ha enviado como parámetro
        /// </summary>
        /// <param name="personasFisicasDTO"></param>
        /// <returns></returns>
        [HttpPut("ActualizarPersonaFisica")]
        public async Task<IActionResult> ActualizarPersonaFisica([FromBody] TbPersonasFisicasDTO personasFisicasDTO)
        {
            try
            {
                var usuarioResponse = await _personaService.ActualizarPersonaFisica(personasFisicasDTO);
                return Ok(usuarioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] TbPersonasFisicasDTO personasFisicasDTO)
        {
            try
            {
                var usuarioResponse = await _personaService.Login(personasFisicasDTO);
                return Ok(usuarioResponse);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion
    }
}

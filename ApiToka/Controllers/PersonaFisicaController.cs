namespace ApiToka.Controllers
{
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
        #endregion
    }
}

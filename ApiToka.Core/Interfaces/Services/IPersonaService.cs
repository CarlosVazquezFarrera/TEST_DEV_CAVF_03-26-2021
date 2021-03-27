namespace ApiToka.Core.Interfaces.Services
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.DTOs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPersonaService
    {
        /// <summary>
        /// Obtiene un registro en específico con base al Id específicado 
        /// </summary>
        /// <returns></returns>
        Task<Response<List<TbPersonasFisicasDTO>>> ObtenerPersonasFisicas();
        /// <summary>
        /// Actualiza un registro con base a los datos especificados 
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> ActualizarPersonaFisica(TbPersonasFisicasDTO personasFisicas);
        /// <summary>
        /// Elimina un registro específico con base a los parametros enviados
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> BorrarPersonaFisica(int IdPersona);
        /// <summary>
        /// Registra los datos que han enviado 
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicasDTO personasFisicas);
        /// <summary>
        /// Ejecuta el login
        /// </summary>
        /// <param name="personasFisicasDTO"></param>
        /// <returns></returns>
        Task<Response<TbPersonasFisicasDTO>> Login(TbPersonasFisicasDTO personasFisicasDTO);
    }
}

namespace ApiToka.Core.Interfaces.Repositories
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.Entites;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IPersonaRepository
    {
        /// <summary>
        /// Obtiene un registro en específico con base al Id específicado 
        /// </summary>
        /// <returns></returns>
        Task<Response<List<TbPersonasFisicas>>> ObtenerPersonasFisicas();
        /// <summary>
        /// Actualiza un registro con base a los datos especificados 
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> ActualizarPersonaFisica(TbPersonasFisicas personasFisicas);
        /// <summary>
        /// Elimina un registro específico con base a los parametros enviados
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> BorrarPersonaFisica(int IdPersona);
        /// <summary>
        /// Registra los datos que han enviado 
        /// </summary>
        /// <returns></returns>
        Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicas personasFisicas);
    }
}

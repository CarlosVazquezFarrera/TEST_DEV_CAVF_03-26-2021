namespace ApiToka.Core.Services
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.DTOs;
    using ApiToka.Core.Interfaces.Repositories;
    using ApiToka.Core.Interfaces.Services;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class PersonaService : IPersonaService
    {
        #region Constructor
        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            this._personaRepository = personaRepository;
            this._mapper = mapper;
        } 
        #endregion
        private IPersonaRepository _personaRepository;
        private IMapper _mapper;
        public Task<SimpleResponse> ActualizarPersonaFisica(TbPersonasFisicasDTO personasFisicas)
        {
            throw new System.NotImplementedException();
        }

        public Task<SimpleResponse> BorrarPersonaFisica(int IdPersona)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<List<TbPersonasFisicasDTO>>> ObtenerPersonasFisicas()
        {
            var responsePersonaFisicaRepository = await _personaRepository.ObtenerPersonasFisicas();

            Response<List<TbPersonasFisicasDTO>> responseDTO = new Response<List<TbPersonasFisicasDTO>>
            {
                Exito = responsePersonaFisicaRepository.Exito,
                Mensaje = responsePersonaFisicaRepository.Mensaje,
                Data = (responsePersonaFisicaRepository.Data.Select(u => _mapper.Map<TbPersonasFisicasDTO>(u))).ToList()
            };
            return responseDTO;
        }

        public Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicasDTO personasFisicas)
        {
            throw new System.NotImplementedException();
        }
    }
}

namespace ApiToka.Core.Services
{
    using ApiToka.Core.CustomEntities;
    using ApiToka.Core.DTOs;
    using ApiToka.Core.Entites;
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

        public async Task<SimpleResponse> BorrarPersonaFisica(int IdPersona)
        {
            if (IdPersona == 0)
                return new SimpleResponse { Exito = 0, Mensaje = "Debe ingresar un Id" };
            return await _personaRepository.BorrarPersonaFisica(IdPersona);
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

        public async Task<SimpleResponse> RegistrarPersonaFisica(TbPersonasFisicasDTO personasFisicas)
        {
            return await _personaRepository.RegistrarPersonaFisica(_mapper.Map<TbPersonasFisicas>(personasFisicas));
        }
    }
}

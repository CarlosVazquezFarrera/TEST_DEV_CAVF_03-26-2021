namespace ApiToka.Infrastrucure.Mapping
{
    using ApiToka.Core.DTOs;
    using ApiToka.Core.Entites;
    using AutoMapper;
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TbPersonasFisicas, TbPersonasFisicasDTO>();
            CreateMap<TbPersonasFisicasDTO, TbPersonasFisicas>();
        }

    }
}

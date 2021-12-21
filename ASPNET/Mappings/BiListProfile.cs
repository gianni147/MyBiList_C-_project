using ASPNET.dto;
using ASPNET.Models;
using ASPNET;
using AutoMapper;


namespace ASPNET.Mappings
{
    public class BiListProfile : Profile
    {

        public BiListProfile()
        {
            CreateMap<BiList, BiListReadDto>();
            CreateMap<BiListWriteDto, BiList>();
            CreateMap<BiListUpdateDto, BiList>();
        }

    }
}
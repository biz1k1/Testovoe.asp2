using Application.DTO;
using AutoMapper;
using Domain.Entity;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
		public MappingProfile()
        {
            CreateMap<RecordEntity, RecordDTO>();
        }
    }
}

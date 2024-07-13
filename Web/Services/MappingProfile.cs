using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Web.Model.ViewModel;
using Web.Models;

namespace Web.Services
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RecordsViewModel, RecordDTO>();
            CreateMap<RecordModel, RecordDTO>();
            CreateMap<RecordDTO, RecordsViewModel>();
            CreateMap<RecordDTO, RecordEntity>();
            CreateMap<RecordDTO, RecordModel>();
            CreateMap<RegistrationModel, RecordDTO>();
        }
    }
}

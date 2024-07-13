using Application.DTO;
using AutoMapper;
using Infrastracture.Persistence.RecordPersistence.Commands;
using Infrastracture.Persistence.RecordPersistence.Queries;
using MediatR;
using Web.Contracts;
using Web.Model.ViewModel;
using Web.Models;

namespace Web.Services
{
    public class RecordService : IRecordService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RecordService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public Task<Guid> CreateRecord(RegistrationModel registrationModel)
        {
            if (registrationModel == null)
            {
                throw new Exception("Error");
            }

            var recordDTO = _mapper.Map<RecordDTO>(registrationModel);

            var newRecordGuid=_mediator.Send(new CreateRecordCommand(recordDTO));

            return newRecordGuid;
        }

        public async Task<RecordsViewModel> GetAllRecords()
        {
            var recordsDTO=await _mediator.Send(new GetAllRecordsQuery());

            var recordViewModel = _mapper.Map<List<RecordModel>>(recordsDTO);
            var model = new RecordsViewModel()
            {
                ListRecords = recordViewModel
            };

            return model;
        }


    }
}

using Infrastracture.Data;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Application.DTO;

namespace Infrastracture.Persistence.RecordPersistence.Commands
{
    public class CreateRecordCommand:IRequest<Guid>
    {
        public RecordDTO RecordDTO { get; set; }
        public CreateRecordCommand(RecordDTO recordDTO)
        {
            RecordDTO = recordDTO;
        }
        public class CreateRecordCommandHandler : IRequestHandler<CreateRecordCommand, Guid>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public CreateRecordCommandHandler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<Guid> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
            {
                var record = await _dataContext.Record.FirstOrDefaultAsync(x=>x.Name==request.RecordDTO.Name);

                if (record != null)
                {
                    throw new Exception(message: "Duplicate product");
                }

                var recordEntity = _mapper.Map<RecordEntity>(request.RecordDTO);

                recordEntity.DateCreation = DateTime.Now;


                await _dataContext.Record.AddAsync(recordEntity);
                await _dataContext.SaveChangesAsync();

                return recordEntity.Id;
            }

        }
    }
}

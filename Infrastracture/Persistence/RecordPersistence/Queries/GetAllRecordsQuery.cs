using Application.DTO;
using AutoMapper;
using Domain.Entity;
using Infrastracture.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Persistence.RecordPersistence.Queries
{
    public class GetAllRecordsQuery:IRequest<List<RecordDTO>>
    {
        public class GetAllRecordsQueryHandler : IRequestHandler<GetAllRecordsQuery,List<RecordDTO>>
        {
            private readonly DataContext _dataContext;
            private readonly IMapper _mapper;
            public GetAllRecordsQueryHandler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
                _mapper = mapper;
            }

            public async Task<List<RecordDTO>> Handle(GetAllRecordsQuery request, CancellationToken cancellationToken)
            {

                var records= await _dataContext.Record.AsNoTracking().OrderByDescending(x=>x.DateCreation).ToListAsync();

                var recordResponse=_mapper.Map<List<RecordDTO>>(records);
                return recordResponse;
            }
        }
    }
}

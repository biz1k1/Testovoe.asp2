using Application.DTO;
using AutoMapper;
using Infrastracture.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Persistence.RecordPersistence.Queries
{
	public class GetRecordByNameQuery:IRequest<RecordDTO>
	{
		public string Name { get; set; }
		public GetRecordByNameQuery(string name)
		{
			Name = name;
		}
		public class GetRecordByNameQueryHandler : IRequestHandler<GetRecordByNameQuery, RecordDTO>
		{
			private readonly DataContext _dataContext;
			private readonly IMapper _mapper;
			public GetRecordByNameQueryHandler(DataContext dataContext, IMapper mapper)
			{
				_dataContext = dataContext;
				_mapper = mapper;
			}

			public async Task<RecordDTO> Handle(GetRecordByNameQuery request, CancellationToken cancellationToken)
			{

				var record = await _dataContext.Record.AsNoTracking().FirstOrDefaultAsync(x => x.Name.Contains(request.Name));

				var recordResponse = _mapper.Map<RecordDTO>(record);
				return recordResponse;
			}
		}
	}
}

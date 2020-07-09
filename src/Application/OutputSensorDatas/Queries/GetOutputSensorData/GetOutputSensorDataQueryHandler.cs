using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OutputSensorDatas.Queries.GetOutputSensorData
{
    public class GetOutputSensorDataQueryHandler : IRequestHandler<GetOutputSensorDataQuery, OutputSensorDataAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetOutputSensorDataQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OutputSensorDataAm> Handle(GetOutputSensorDataQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.OutputSensorData
                .FirstOrDefaultAsync(o => o.SensorBlockId == request.SensorBlockId, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OutputSensorData), request.SensorBlockId);
            }

            return _mapper.Map<OutputSensorDataAm>(entity);
        }
    }
}
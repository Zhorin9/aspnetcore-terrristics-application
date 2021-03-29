using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ControlSensors.Queries.GetControlSensor
{
    public class GetControlSensorQueryHandler : IRequestHandler<GetControlSensorQuery, ControlSensorAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetControlSensorQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ControlSensorAm> Handle(GetControlSensorQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.ControlSensors
                .FirstOrDefaultAsync(o => o.SensorBlockId == request.SensorBlockId, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ControlSensor), request.SensorBlockId);
            }

            return _mapper.Map<ControlSensorAm>(entity);
        }
    }
}
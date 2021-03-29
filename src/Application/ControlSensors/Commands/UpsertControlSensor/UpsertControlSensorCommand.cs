using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ControlSensors.Commands.UpsertControlSensor
{
    public class UpsertControlSensorCommand : IRequest
    {
        public int SensorBlockId { get; set; }

        public bool State { get; set; }
        public string Value { get; set; }

        public class Handler : IRequestHandler<UpsertControlSensorCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpsertControlSensorCommand request, CancellationToken cancellationToken)
            {
                SensorBlock sensorBlock = await _context.SensorBlocks
                    .Include(i => i.ControlSensor)
                    .FirstOrDefaultAsync(sb => sb.Id == request.SensorBlockId, cancellationToken: cancellationToken);

                if (sensorBlock == null)
                {
                    throw new NotFoundException(nameof(sensorBlock), request.SensorBlockId);
                }

                if (sensorBlock.ControlSensor == null)
                {
                    sensorBlock.ControlSensor = new ControlSensor
                    {
                        SensorBlockId = request.SensorBlockId,
                        State = request.State,
                        Value = request.Value
                    };
                }
                else
                {
                    sensorBlock.ControlSensor.State = request.State;
                    sensorBlock.ControlSensor.Value = request.Value;
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OutputSensorDatas.Commands.UpsertOutputSensorData
{
    public class UpsertOutputSensorDataCommand : IRequest
    {
        public int SensorBlockId { get; set; }

        public bool State { get; set; }
        public string Value { get; set; }

        public class Handler : IRequestHandler<UpsertOutputSensorDataCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpsertOutputSensorDataCommand request, CancellationToken cancellationToken)
            {
                SensorBlock sensorBlock = await _context.SensorBlocks
                    .Include(i => i.OutputData)
                    .FirstOrDefaultAsync(sb => sb.Id == request.SensorBlockId, cancellationToken: cancellationToken);

                if (sensorBlock == null)
                {
                    throw new NotFoundException(nameof(sensorBlock), request.SensorBlockId);
                }

                if (sensorBlock.OutputData == null)
                {
                    sensorBlock.OutputData = new OutputSensorData
                    {
                        SensorBlockId = request.SensorBlockId,
                        State = request.State,
                        Value = request.Value
                    };
                }
                else
                {
                    sensorBlock.OutputData.State = request.State;
                    sensorBlock.OutputData.Value = request.Value;
                }

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
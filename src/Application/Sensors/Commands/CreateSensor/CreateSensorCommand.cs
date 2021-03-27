using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Sensors.Commands.CreateSensor
{
    public class CreateSensorCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int WindowId { get; set; }

        public SensorKindAm SensorKind { get; set; }

        public class Handler : IRequestHandler<CreateSensorCommand, int>
        {
            private readonly IAppDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            
            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(CreateSensorCommand request, CancellationToken cancellationToken)
            {
                SensorBlock entity = GetNewSensorBlock(request);
                
                await _context.SensorBlocks.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }

            private SensorBlock GetNewSensorBlock(CreateSensorCommand request)
            {
                SensorBlock sensorBlock = new SensorBlock
                {
                    Name = request.Name,
                    Description = request.Description,
                    UserId = _currentUserService.UserId,
                    ParentWindowId = request.WindowId,
                    SensorKindId = request.SensorKind.SensorKindId
                };
                
                UpdateSensorBlockTypeDependOnKind(request, sensorBlock);

                return sensorBlock;
            }

            private static void UpdateSensorBlockTypeDependOnKind(CreateSensorCommand request, SensorBlock entity)
            {
                if (request.SensorKind.Type == SensorTypeEnum.Output)
                {
                    entity.OutputData = new OutputSensorData
                    {
                        Value = "",
                        State = false
                    };
                }
            }
        }
    }
}
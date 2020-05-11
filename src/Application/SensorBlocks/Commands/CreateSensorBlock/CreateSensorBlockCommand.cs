using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.SensorBlocks.Commands.CreateSensorBlock
{
    public class CreateSensorBlockCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int WindowId { get; set; }

        public SensorKindAm SensorKind { get; set; }

        public class Handler : IRequestHandler<CreateSensorBlockCommand>
        {
            private readonly IAppDbContext _context;
            private readonly ICurrentUserService _currentUserService;
            
            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(CreateSensorBlockCommand request, CancellationToken cancellationToken)
            {
                var entity = new SensorBlock
                {
                    Name = request.Name,
                    Description = request.Description,
                    UserId = _currentUserService.UserId,
                    ParentWindowId = request.WindowId,
                    SensorKindId = request.SensorKind.SensorKindId
                };
                
                if (request.SensorKind.Type == SensorTypeEnum.Output)
                {
                    entity.OutputData = new OutputSensorData
                    {
                        Value = "",
                        State = false
                    };
                }
                
                await _context.SensorBlocks.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
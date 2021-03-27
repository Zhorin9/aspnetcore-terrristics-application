using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sensors.Commands.UpdateSensor
{
    public class UpdateSensorCommand : IRequest<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public class Handler : IRequestHandler<UpdateSensorCommand, int>
        {
            private readonly IAppDbContext _context;

            private readonly ICurrentUserService _currentUserService;

            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
            {
                SensorBlock entity = await _context.SensorBlocks
                    .FirstOrDefaultAsync(s => s.Id == request.Id && s.UserId == _currentUserService.UserId, cancellationToken: cancellationToken);

                entity.Name = request.Name;
                entity.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
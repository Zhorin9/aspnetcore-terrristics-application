using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SensorBlocks.Commands.UpdateSensorBlock
{
    public class UpdateSensorBlockCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public class Handler : IRequestHandler<UpdateSensorBlockCommand>
        {
            private readonly IAppDbContext _context;

            private readonly ICurrentUserService _currentUserService;

            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(UpdateSensorBlockCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.SensorBlocks
                    .FirstOrDefaultAsync(s => s.Id == request.Id && s.UserId == _currentUserService.UserId, cancellationToken: cancellationToken);

                entity.Name = request.Name;
                entity.Description = request.Description;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
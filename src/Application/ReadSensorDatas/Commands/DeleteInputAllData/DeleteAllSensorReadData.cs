using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.ReadSensorData.Commands.DeleteInputAllData
{
    public class DeleteAllSensorReadData : IRequest
    {
        public int SensorBlockId { get; set; }
        
        public class DeleteInputBlockAllDataCommandHandler : IRequestHandler<DeleteAllSensorReadData>
        {
            private readonly IAppDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public DeleteInputBlockAllDataCommandHandler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(DeleteAllSensorReadData request, CancellationToken cancellationToken)
            {
                SensorBlock sensorBlock = await _context.SensorBlocks
                    .Include(i => i.ReadSensorData)
                    .FirstOrDefaultAsync(s => s.UserId == _currentUserService.UserId && s.Id == request.SensorBlockId, cancellationToken: cancellationToken);
                
                if (sensorBlock == null)
                {
                    throw new NotFoundException(nameof(sensorBlock), request.SensorBlockId);
                }

                _context.ReadSensorData.RemoveRange(sensorBlock.Reads);
                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}
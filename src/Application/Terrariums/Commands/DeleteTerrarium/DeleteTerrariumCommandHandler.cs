using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.Terrariums.Commands.DeleteTerrarium
{
    public class DeleteTerrariumCommandHandler : IRequestHandler<DeleteTerrariumCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteTerrariumCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTerrariumCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TerraristicWindows
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TerraristicWindows), request.Id);
            }

            //TODO should change to remove if doesn't have sensorblock

            _context.TerraristicWindows.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
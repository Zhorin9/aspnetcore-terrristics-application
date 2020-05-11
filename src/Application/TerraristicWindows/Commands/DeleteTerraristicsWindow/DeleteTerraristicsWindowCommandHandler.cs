using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Exceptions;
using MediatR;

namespace Application.TerraristicWindows.Commands.DeleteTerraristicsWindow
{
    public class DeleteTerraristicsWindowCommandHandler : IRequestHandler<DeleteTerraristicsWindowCommand>
    {
        private readonly IAppDbContext _context;

        public DeleteTerraristicsWindowCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteTerraristicsWindowCommand request, CancellationToken cancellationToken)
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
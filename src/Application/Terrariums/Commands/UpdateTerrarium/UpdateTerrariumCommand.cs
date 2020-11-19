using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Terrariums.Commands.UpdateTerrarium
{
    public class UpdateTerrariumCommand : IRequest
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }
        
        public class Handler : IRequestHandler<UpdateTerrariumCommand>
        {
            private readonly IAppDbContext _context;

            public Handler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateTerrariumCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.TerraristicWindows
                    .SingleOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(TerraristicWindow), request.Id);
                }
                
                entity.Name = request.Name;
                entity.Description = request.Description;
                entity.IsPublic = request.IsPublic;
                entity.ModificationDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Terrariums.Commands.CreateTerrarium
{
    public class CreateTerrariumCommand : IRequest<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }
        
        public class Handler : IRequestHandler<CreateTerrariumCommand, int>
        {
            private readonly IAppDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<int> Handle(CreateTerrariumCommand request, CancellationToken cancellationToken)
            {
                var entity = new TerraristicWindow
                {
                    Name = request.Name,
                    Description = request.Description,
                    UserId = _currentUserService.UserId,
                    ApiKey = Guid.NewGuid(),
                    IsPublic = request.IsPublic
                };

                await _context.TerraristicWindows.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}
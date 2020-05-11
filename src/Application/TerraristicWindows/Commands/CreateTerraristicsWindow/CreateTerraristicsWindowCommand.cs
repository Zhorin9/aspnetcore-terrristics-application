using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.TerraristicWindows.Commands.CreateTerraristicsWindow
{
    public class CreateTerraristicsWindowCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPublic { get; set; }
        
        public class Handler : IRequestHandler<CreateTerraristicsWindowCommand>
        {
            private readonly IAppDbContext _context;
            private readonly ICurrentUserService _currentUserService;

            public Handler(IAppDbContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<Unit> Handle(CreateTerraristicsWindowCommand request, CancellationToken cancellationToken)
            {
                var entity = new TerraristicWindow
                {
                    Name = request.Name,
                    Description = request.Description,
                    UserId = _currentUserService.UserId,
                    ApiKey = Guid.NewGuid(),
                    CreationDate = DateTime.Now.Date,
                    ModificationDate = DateTime.Now.Date,
                    IsPublic = request.IsPublic
                };

                await _context.TerraristicWindows.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
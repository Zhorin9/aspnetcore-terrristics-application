using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Terrariums.Queries.GetTerrariumDetail
{
    public class GetTerrariumDetailQueryHandler : IRequestHandler<GetTerrariumDetailQuery, TerrariumDetailAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTerrariumDetailQueryHandler(IMapper mapper, IAppDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<TerrariumDetailAm> Handle(GetTerrariumDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.TerraristicWindows
                .FirstOrDefaultAsync(p => p.Id == request.Id && p.UserId == _currentUserService.UserId, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TerraristicWindow), request.Id);
            }

            return _mapper.Map<TerrariumDetailAm>(entity);
        }
    }
}
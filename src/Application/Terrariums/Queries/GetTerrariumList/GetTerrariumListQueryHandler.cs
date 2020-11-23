using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Terrariums.Queries.GetTerrariumList
{
    public class GetTerrariumListQueryHandler : IRequestHandler<GetTerrariumListQuery, TerrariumListAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTerrariumListQueryHandler(IMapper mapper, IAppDbContext context,
            ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<TerrariumListAm> Handle(GetTerrariumListQuery request, CancellationToken cancellationToken)
        {
            List<TerrariumListDetailAm> terraristicsWindows = await _context.TerraristicWindows
                .Where(p => p.UserId == _currentUserService.UserId)
                .ProjectTo<TerrariumListDetailAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var am = new TerrariumListAm
            {
                Terrariums = terraristicsWindows
            };

            return am;
        }
    }
}
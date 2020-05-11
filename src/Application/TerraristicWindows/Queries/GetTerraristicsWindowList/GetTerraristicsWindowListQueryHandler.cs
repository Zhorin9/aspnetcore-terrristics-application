using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.TerraristicWindows.Queries.GetTerraristicsWindowList
{
    public class GetTerraristicsWindowListQueryHandler : IRequestHandler<GetTerraristicsWindowListQuery, TerraristicsWindowListAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetTerraristicsWindowListQueryHandler(IMapper mapper, IAppDbContext context, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _context = context;
            _currentUserService = currentUserService;
        }
        
        public async Task<TerraristicsWindowListAm> Handle(GetTerraristicsWindowListQuery request, CancellationToken cancellationToken)
        {
            List<TerraristicsWindowListDetailAm> terraristicsWindows = await _context.TerraristicWindows
                .Where(p => p.UserId == _currentUserService.UserId)
                .ProjectTo<TerraristicsWindowListDetailAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var am = new TerraristicsWindowListAm
            {
                TerraristicsWindows = terraristicsWindows
            };

            return am;
        }
    }
}
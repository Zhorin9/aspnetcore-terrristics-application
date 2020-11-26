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

namespace Application.Sensors.Queries.GetSensorBlockList
{
    public class GetSensorBlockListQueryHandler : IRequestHandler<GetSensorBlockListQuery, SensorBlockListAm>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        
        public GetSensorBlockListQueryHandler(IAppDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        
        public async Task<SensorBlockListAm> Handle(GetSensorBlockListQuery request, CancellationToken cancellationToken)
        {
            List<SensorBlockListDetailAm> sensorBlocks = await _context.SensorBlocks
                .AsNoTracking()
                .Include(sb => sb.SensorKind)
                .Where(sb => sb.ParentWindowId == request.WindowId && sb.UserId == _currentUserService.UserId)
                .ProjectTo<SensorBlockListDetailAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
            
            var am = new SensorBlockListAm
            {
                SensorBlocks = sensorBlocks
            };

            return am;
        }
    }
}
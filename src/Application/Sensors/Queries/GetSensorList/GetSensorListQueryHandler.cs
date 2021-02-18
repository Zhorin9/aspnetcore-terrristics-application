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

namespace Application.Sensors.Queries.GetSensorList
{
    public class GetSensorListQueryHandler : IRequestHandler<GetSensorListQuery, SensorListAm>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        
        public GetSensorListQueryHandler(IAppDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        
        public async Task<SensorListAm> Handle(GetSensorListQuery request, CancellationToken cancellationToken)
        {
            List<SensorListDetailAm> sensorBlocks = await _context.SensorBlocks
                .AsNoTracking()
                .Include(sb => sb.SensorKind)
                .Where(sb => sb.ParentWindowId == request.WindowId && sb.UserId == _currentUserService.UserId)
                .ProjectTo<SensorListDetailAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
            
            var am = new SensorListAm
            {
                SensorBlocks = sensorBlocks
            };

            return am;
        }
    }
}
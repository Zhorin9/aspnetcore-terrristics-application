using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sensors.Queries.GetSensorDetail
{
    public class GetSensorDetailQueryHandler : IRequestHandler<GetSensorDetailQuery, SensorDetailAm>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetSensorDetailQueryHandler(IAppDbContext context, ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<SensorDetailAm> Handle(GetSensorDetailQuery request, CancellationToken cancellationToken)
        {
            SensorDetailAm am = await _context.SensorBlocks
                .Where(sb => sb.Id == request.Id && sb.UserId == _currentUserService.UserId)
                .ProjectTo<SensorDetailAm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (am == null)
            {
                throw new NotFoundException(nameof(SensorBlock), request.Id);
            }

            return am;
        }
    }
}
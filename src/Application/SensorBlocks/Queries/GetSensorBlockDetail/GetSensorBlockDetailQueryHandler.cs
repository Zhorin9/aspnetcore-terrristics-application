using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SensorBlocks.Queries.GetSensorBlockDetail
{
    public class GetSensorBlockDetailQueryHandler : IRequestHandler<GetSensorBlockDetailQuery, SensorBlockDetailAm>
    {
        private readonly IAppDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;

        public GetSensorBlockDetailQueryHandler(IAppDbContext context, ICurrentUserService currentUserService, IMapper mapper)
        {
            _context = context;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<SensorBlockDetailAm> Handle(GetSensorBlockDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SensorBlocks
                .FirstOrDefaultAsync(sb => sb.Id == request.Id && sb.UserId == _currentUserService.UserId, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SensorBlock), request.Id);
            }

            return _mapper.Map<SensorBlockDetailAm>(entity);
        }
    }
}
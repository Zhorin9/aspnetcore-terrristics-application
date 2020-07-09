using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.SensorKinds.Queries.GetSensorKindList
{
    public class GetSensorKindListQueryHandler : IRequestHandler<GetSensorKindListQuery, List<SensorKindAm>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetSensorKindListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<SensorKindAm>> Handle(GetSensorKindListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.SensorKinds
                .ProjectTo<SensorKindAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            return entities;
        }
    }
}
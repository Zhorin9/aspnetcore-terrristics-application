using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.InputSensorDatas.Queries.GetInputSensorDataList
{
    public class GetInputSensorDataListQueryHandler : IRequestHandler<GetInputSensorDataListQuery, InputSensorDataListAm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetInputSensorDataListQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InputSensorDataListAm> Handle(GetInputSensorDataListQuery request, CancellationToken cancellationToken)
        {
            List<InputSensorDataListDetailAm> sensorBlocks = await _context.ReadSensorData.Where(d => d.SensorBlockId == request.SensorBlockId)
                .AsNoTracking()
                .ProjectTo<InputSensorDataListDetailAm>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);

            var am = new InputSensorDataListAm
            {
                SensorBlockData = sensorBlocks
            };

            return am;
        }
    }
}